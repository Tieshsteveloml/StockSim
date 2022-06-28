using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using IBApi;
using StockSim.messages;
using StockSim.util;
using StockSim.types;
using StockSim.ui;
using System.IO;


namespace StockSim
{

    partial class StockSim : Form
    {
        private MarketDataManager marketDataManager;
        private HistoricalDataManager historicalDataManager;
        //private OptionsManager optionsManager;
        protected IBClient ibClient;
        private EReaderMonitorSignal signal = new EReaderMonitorSignal();
        private int numberOfLinesInMessageBox;
        private const int MAX_LINES_IN_MESSAGE_BOX = 200;
        private const int REDUCED_LINES_IN_MESSAGE_BOX = 100;
        private List<string> linesInMessageBox = new List<string>(MAX_LINES_IN_MESSAGE_BOX);
        private List<string> symbolList = new List<string>() { "GOOGL", "TSLA", "AAPL", "AMD" };
        private List<Contract> contractList = new List<Contract>();
        private List<Contract> selectedContractList = new List<Contract>();
        private string stockFilePath = "config/stocks.csv";
        private string barSize = "1 min";
        private string whatToShow = "TRADES";
        private int outsideRTH = 0;
        private string endTime;
        public bool IsConnected { get; set; }
        public StockSim()
        {
            InitializeComponent();
            LoadContracts();
            ibClient = new IBClient(signal);
            marketDataManager = new MarketDataManager(ibClient, DG_STOCKS);
            historicalDataManager = new HistoricalDataManager(ibClient, null, DG_RESULT);
            //optionsManager = new OptionsManager(ibClient, optionChainCallGrid, optionChainPutGrid, optionPositionsGrid, listViewOptionParams);

            ibClient.ConnectionClosed += ibClient_ConnectionClosed;
            ibClient.NextValidId += UpdateUI;
            ibClient.TickPrice += ibClient_Tick;
            ibClient.TickSize += ibClient_Tick;
            ibClient.MarketDataType += UpdateUI;

            ibClient.HistoricalData += historicalDataManager.UpdateUI;
            ibClient.HistoricalDataUpdate += historicalDataManager.UpdateUI;
            ibClient.HistoricalDataEnd += historicalDataManager.UpdateUI;
        }

        private bool LoadContracts()
        {
            try
            {
                StreamReader file;
                string line;
                file = new StreamReader(stockFilePath);

                contractList.Clear();
                bool header = false;
                while ((line = file.ReadLine()) != null)
                {
                    if (!header)
                    {
                        header = true;
                        continue;
                    }
                    string[] result = line.Split(',');
                    if (result.Length < 9) continue;
                    string symbol, sec = "STK", exc = "SMART", cur = "USD", ltm = "", pex = "", strike = "", mul = "", lsym = "";
                    symbol = result[0];
                    if (symbol.Length <= 0) continue;
                    sec = result[1] == "" ? sec : result[1];
                    exc = result[2] == "" ? exc : result[2];
                    cur = result[3] == "" ? cur : result[3];
                    ltm = result[4] == "" ? ltm : result[4];
                    pex = result[5] == "" ? pex : result[5];
                    strike = result[6] == "" ? strike : result[6];
                    mul = result[7] == "" ? mul : result[7];
                    lsym = result[8] == "" ? lsym : result[8];
                    contractList.Add(GetContract(symbol, sec, exc, cur, ltm, pex, strike, mul, lsym));
                }
                file.Close();
                return contractList.Count > 0;
            }
            catch (Exception e)
            {
                ibClient_Error(-1, -1, "", e);
            }
            return false;
        }

        void ibClient_Tick(TickSizeMessage msg)
        {
            // addTextToBox("Tick Size. Ticker Id:" + msg.RequestId + ", Type: " + TickType.getField(msg.Field) + ", Size: " + msg.Size + "\n");

            if (msg.RequestId < OptionsManager.OPTIONS_ID_BASE)
            {
                if (marketDataManager.IsUIUpdateRequired(msg))
                    marketDataManager.UpdateUI(msg);
            }
            else
            {
                HandleTickMessage(msg);
            }
        }

        void ibClient_Tick(TickPriceMessage msg)
        {
            // addTextToBox("Tick Price. Ticker Id:" + msg.RequestId + ", Type: " + TickType.getField(msg.Field) + ", Price: " + msg.Price + ", Pre-Open: " + msg.Attribs.PreOpen + "\n");

            if (msg.RequestId < OptionsManager.OPTIONS_ID_BASE)
            {
                if (marketDataManager.IsUIUpdateRequired(msg))
                    marketDataManager.UpdateUI(msg);
            }
            else
            {
                HandleTickMessage(msg);
            }
        }

        private void HandleTickMessage(MarketDataMessage tickMessage)
        {
            //optionsManager.UpdateUI(tickMessage);
        }

        private void StockSim_Load(object sender, EventArgs e)
        {

        }

        void ibClient_ConnectionClosed()
        {
            IsConnected = false;
            UpdateUI(new ConnectionStatusMessage(false));
        }

        void ibClient_Error(int id, int errorCode, string str, Exception ex)
        {
            if (ex != null)
            {
                addTextToBox("Error: " + ex);

                return;
            }

            if (id == 0 || errorCode == 0)
            {
                addTextToBox("Error: " + str + "\n");

                return;
            }

            ErrorMessage error = new ErrorMessage(id, errorCode, str);

            HandleErrorMessage(error);
        }


        private void addTextToBox(string text)
        {
            HandleErrorMessage(new ErrorMessage(-1, -1, text));
        }

        private double stringToDouble(string number)
        {
            if (number != null && !number.Equals(""))
                return double.Parse(number);
            else
                return 0;
        }

        private Contract GetContract(string symbol = "AAPL", string sec = "STK", string exc = "SMART", string cur = "USD", string ltm = "", string pex = "", string strike = "", string mul = "", string lsym = "")
        {
            Contract contract = new Contract();
            contract.SecType = sec;
            contract.Symbol = symbol;
            contract.Exchange = exc;
            contract.Currency = cur;
            contract.LastTradeDateOrContractMonth = ltm;
            contract.PrimaryExch = pex;
            contract.Strike = stringToDouble(strike);
            contract.Multiplier = mul;
            contract.LocalSymbol = lsym;

            return contract;
        }

        private void UpdateUI(MarketDataTypeMessage message)
        {
            if (marketDataManager.isActive())
            {
                marketDataManager.HandleMarketDataTypeMessage(message);
            }
        }

        private void ShowTab(TabControl tabControl, TabPage page)
        {
            if (!tabControl.Contains(page))
            {
                tabControl.TabPages.Add(page);
            }
            tabControl.SelectedTab = page;
        }

        private void SubscribeContract()
        {
            if (IsConnected)
            {
                marketDataManager.Clear();
                foreach (var s in contractList)
                {
                    marketDataManager.AddRequest(s, "");
                }
                //ShowTab(marketData_MDT, topMarketDataTab_MDT);
            }
        }

        private void UpdateUI(ConnectionStatusMessage statusMessage)
        {
            IsConnected = statusMessage.IsConnected;

            if (statusMessage.IsConnected)
            {
                LA_STATUS.Text = "Connected! Your client Id: " + ibClient.ClientId;
                BTN_CONNECT.Text = "Disconnect";
                SubscribeContract();
            }
            else
            {
                LA_STATUS.Text = "Disconnected...";
                BTN_CONNECT.Text = "Connect";
            }
        }
        private void BTN_CONNECT_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                int port;
                string host = TXT_HOST.Text;

                if (host == null || host.Equals(""))
                    host = "127.0.0.1";
                try
                {
                    port = int.Parse(TXT_PORT.Text);
                    ibClient.ClientId = int.Parse(TXT_CLIENTID.Text);
                    ibClient.ClientSocket.eConnect(host, port, ibClient.ClientId);

                    var reader = new EReader(ibClient.ClientSocket, signal);

                    reader.Start();

                    new Thread(() => { while (ibClient.ClientSocket.IsConnected()) { signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();
                }
                catch (Exception)
                {
                    HandleErrorMessage(new ErrorMessage(-1, -1, "Please check your connection attributes."));
                }
            }
            else
            {
                IsConnected = false;
                ibClient.ClientSocket.eDisconnect();
            }
        }

        private void ShowMessageOnPanel(string message)
        {
            message = ensureMessageHasNewline(message);

            if (numberOfLinesInMessageBox >= MAX_LINES_IN_MESSAGE_BOX)
            {
                linesInMessageBox.RemoveRange(0, MAX_LINES_IN_MESSAGE_BOX - REDUCED_LINES_IN_MESSAGE_BOX);
                messageBox.Lines = linesInMessageBox.ToArray();
                numberOfLinesInMessageBox = REDUCED_LINES_IN_MESSAGE_BOX;
            }

            linesInMessageBox.Add(message);
            numberOfLinesInMessageBox += 1;
            messageBox.AppendText(message);
        }

        private string ensureMessageHasNewline(string message)
        {
            if (message.Substring(message.Length - 1) != "\n")
            {
                return message + "\n";
            }
            else
            {
                return message;
            }
        }

        private void HandleErrorMessage(ErrorMessage message)
        {
            ShowMessageOnPanel("Request " + message.RequestId + ", Code: " + message.ErrorCode + " - " + message.Message);
            if (message.RequestId > MarketDataManager.TICK_ID_BASE && message.RequestId < DeepBookManager.TICK_ID_BASE)
                marketDataManager.NotifyError(message.RequestId);
        }


        private void SelectedContracts()
        {
            selectedContractList.Clear();
            var selected = marketDataManager.SelectedSymbols();
            if (selected.Count <= 0) return;
            foreach (var s in contractList)
            {
                if (!selected.Contains(s.Symbol)) continue;
                selectedContractList.Add(s);
            }
        }
        public void MessageBoxEx(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            // Displays the MessageBox.
            MessageBox.Show(message, caption, buttons);
        }

        private void BTN_BACKTEST_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsConnected) return;
                SelectedContracts();
                if (selectedContractList.Count <= 0)
                {
                    MessageBoxEx("Please select one or more symbols", "Alarm");
                    return;
                }
                endTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                string duration = TXT_DURATION.Text.Trim() + " " + CB_DURATION.Text.Trim();
                historicalDataManager.Clear();
                double range = Convert.ToDouble(TXT_RANGE.Text.Trim());
                double stoploss = Convert.ToDouble(TXT_STOPLOSS.Text.Trim());
                double takeprofit = Convert.ToDouble(TXT_TAKEPROFIT.Text.Trim());
                if (range == 0 || stoploss == 0 || takeprofit == 0)
                {
                    MessageBoxEx("all paramters should be greater than 0!", "Error");
                    return;
                }
                for (int i = 0; i < selectedContractList.Count; i++)
                {
                    historicalDataManager.AddRequest(selectedContractList[i], i, endTime, duration, barSize, whatToShow, outsideRTH, 1, false, range, stoploss, takeprofit);
                }
            }
            catch (Exception ex)
            {
                ibClient_Error(-1, -1, "", ex);
            }
        }
    }
}
