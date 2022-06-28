using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBApi;
using StockSim.messages;
using System.Globalization;
using StockSim.util;
using System.Windows.Forms;
using System.IO;


namespace StockSim.ui
{

    enum OrderType
    {
        NoRange = 0,
        NoTriggered,
        Long,
        Short,
    }
    class DayTrade {
        public int date;
        public double openPrice; // market open price
        public double tradePrice; // trade session price
        public OrderType type;
        public DateTime openTime;
        public DateTime closeTime;
        public double closePrice;
        public double result;
        public double stoploss;
        public double takeprofit;
        public DayTrade()
        {
            date = -1;
            openPrice = -1;
            tradePrice = -1;
            type = OrderType.NoRange;
            openTime = DateTime.MinValue;
            closeTime = DateTime.MinValue;
            closePrice = -1;
            result = 0;
            stoploss = -1;
            takeprofit = -1;
        }
    }

    class StrategyManager
    {
        string _marketOpenTime = "04:00";
        string _tradeBeginTime = "09:30";
        string _tradeEndTime = "15:30";
        Contract _contract;
        List<HistoricalDataMessage> _historicalDataMessages;
        TimeZone _localZone = TimeZone.CurrentTimeZone;
        TimeZoneInfo _easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        double _range;
        double _stoploss;
        double _takeprofit;
        Dictionary<int, DayTrade> _orders;
        double _totalResult = 0;
        double _noRange = 0;
        double _noTriggered = 0;
        double _profitOrders = 0;
        double _lossOrders = 0;
        protected DataGridView _gridView;
        List<string> _lines;
        string _resultPath = "result/";
        string _columHeaders = "Symbol,Date,Type,BluePrice,GreenPrice,OpenBarTime,OpenPrice,ClosePrice,CloseBarTime,Result(%)";
        public StrategyManager(Contract contract, double range, double stoploss, double takeprofit, DataGridView gridView)
        {
            _contract = contract;
            _historicalDataMessages = new List<HistoricalDataMessage>();
            _range = range;
            _stoploss = stoploss;
            _takeprofit = takeprofit;
            _gridView = gridView;
            _orders = new Dictionary<int, DayTrade>();
            _lines = new List<string>();
        }
        public void AddBar(HistoricalDataMessage msg)
        {
            _historicalDataMessages.Add(msg);
        }
        public void Clear()
        {
            _historicalDataMessages.Clear();
            _orders.Clear();
            _lines.Clear();
        }
        public void Strategy()
        {
            try
            {
                if (_historicalDataMessages.Count <= 0) return;

                foreach (var bar in _historicalDataMessages)
                {
                    var btime = Utils.LocalToAnyTimezone(bar.Date, _easternZone);
                    int date = Utils.DateToInt(btime);
                    if (!_orders.ContainsKey(date))
                    {
                        _orders[date] = new DayTrade();
                        _orders[date].date = date;
                    }
                    else if (_orders[date].closePrice != -1) continue;

                    if (_orders[date].openPrice == -1 && Utils.IsMatchedTime(btime, _marketOpenTime))
                    {
                        _orders[date].openPrice = bar.Open;
                        _orders[date].stoploss = _orders[date].openPrice * _stoploss / 100;
                        _orders[date].takeprofit = _orders[date].openPrice * _takeprofit / 100;
                        continue;
                    }
                    else if (_orders[date].tradePrice == -1 && Utils.IsMatchedTime(btime, _tradeBeginTime))
                    {
                        _orders[date].tradePrice = bar.Open;
                        double dr = _orders[date].openPrice * _range / 100;
                        double diff = Math.Abs(_orders[date].openPrice - _orders[date].tradePrice);
                        if (diff < dr)
                            _orders[date].type = OrderType.NoRange;
                        else
                            _orders[date].type = OrderType.NoTriggered;
                    }
                    if (_orders[date].type == OrderType.NoRange) continue;
                    if (!Utils.IsInTime(btime, _tradeBeginTime, _tradeEndTime)) continue;
                    if (_orders[date].type == OrderType.NoTriggered)
                    {
                        if (_orders[date].openPrice <= bar.High && _orders[date].openPrice > _orders[date].tradePrice)
                        {
                            _orders[date].type = OrderType.Short;
                            _orders[date].openTime = btime;
                        }
                        else if (_orders[date].openPrice >= bar.Low && _orders[date].openPrice < _orders[date].tradePrice)
                        {
                            _orders[date].type = OrderType.Long;
                            _orders[date].openTime = btime;
                        }
                        else continue;
                    }
                    if (_orders[date].type == OrderType.Short)
                    {
                        var diff = bar.High - _orders[date].openPrice;
                        if (diff >= _orders[date].stoploss)
                        {
                            _orders[date].closePrice = _orders[date].openPrice + _orders[date].stoploss;
                            _orders[date].result = -_stoploss;
                            _orders[date].closeTime = btime;
                            continue;
                        }
                        diff = _orders[date].openPrice - bar.Low;
                        if (diff >= _orders[date].takeprofit)
                        {
                            _orders[date].closePrice = _orders[date].openPrice - _orders[date].takeprofit;
                            _orders[date].result = _takeprofit;
                            _orders[date].closeTime = btime;
                            continue;
                        }
                    }
                    else if (_orders[date].type == OrderType.Long)
                    {
                        var diff = _orders[date].openPrice - bar.Low;
                        if (diff >= _orders[date].stoploss)
                        {
                            _orders[date].closePrice = _orders[date].openPrice - _orders[date].stoploss;
                            _orders[date].result = -_stoploss;
                            _orders[date].closeTime = btime;
                            continue;
                        }
                        diff = bar.High - _orders[date].openPrice;
                        if (diff >= _orders[date].takeprofit)
                        {
                            _orders[date].closePrice = _orders[date].openPrice + _orders[date].takeprofit;
                            _orders[date].result = _takeprofit;
                            _orders[date].closeTime = btime;
                            continue;
                        }
                    }
                    else continue;

                    if (Utils.IsMatchedTime(btime, _tradeEndTime))
                    {
                        _orders[date].closePrice = bar.Open;
                        _orders[date].closeTime = btime;
                        if (_orders[date].type == OrderType.Short)
                            _orders[date].result = (_orders[date].openPrice - _orders[date].closePrice) / _orders[date].openPrice * 100;
                        else if (_orders[date].type == OrderType.Long)
                            _orders[date].result = (_orders[date].closePrice - _orders[date].openPrice) / _orders[date].openPrice * 100;
                        _orders[date].result = Math.Round(_orders[date].result, 2);
                    }
                }
                _totalResult = 0;
                _noRange = 0;
                _noTriggered = 0;
                _profitOrders = 0;
                _lossOrders = 0;
                _lines.Clear();
                foreach (var od in _orders)
                {
                    string line = _contract.Symbol + "," + Convert.ToString(od.Value.date) + ",";
                    switch (od.Value.type)
                    {
                        case OrderType.NoRange:
                            line += "No Range,";
                            _noRange++;
                            break;
                        case OrderType.NoTriggered:
                            line += "No Triggered,";
                            _noTriggered++;
                            break;
                        default:
                            {
                                if (od.Value.result > 0)
                                    _profitOrders++;
                                else if (od.Value.result < 0)
                                    _lossOrders++;
                                _totalResult += od.Value.result;
                                if (od.Value.type == OrderType.Long)
                                    line += "Long,";
                                else 
                                    line += "Short,";
                                break;
                            }
                    }
                    line += od.Value.openPrice.ToString() + "," + od.Value.tradePrice.ToString() + ",";
                    if (od.Value.type == OrderType.NoRange || od.Value.type == OrderType.NoTriggered)
                    {
                        line += ",,,,,";
                    }
                    else
                    {
                        line += od.Value.openTime.ToString() + ",";
                        line += od.Value.openPrice.ToString() + ",";
                        line += od.Value.closePrice.ToString() + ",";
                        line += od.Value.closeTime.ToString() + ",";
                        line += od.Value.result.ToString() + ",";
                    }
                    _lines.Add(line);
                }
                PopulateGrid();
                SaveCsv();
            }
            catch (Exception ex)
            {
                PopulateGrid(ex);
            }            
        }
        private void SaveCsv()
        {
            using (StreamWriter file = new StreamWriter(_resultPath + _contract.Symbol + ".csv"))
            {
                file.WriteLine(_columHeaders);
                foreach (var line in _lines)
                {
                    file.WriteLine(line);
                }
            }
                
        }
        protected void PopulateGrid(Exception ex = null)
        {
            var now = DateTime.Now.ToString("yyyyMMdd  HH:mm:ss");
            _gridView.Rows.Add(1);
            _gridView[0, _gridView.Rows.Count - 1].Value = now;
            _gridView[1, _gridView.Rows.Count - 1].Value = Utils.ContractToString(_contract);
            if (ex != null)
            {
                _gridView[2, _gridView.Rows.Count - 1].Value = ex.ToString();
                return;
            }
            
            _gridView[2, _gridView.Rows.Count - 1].Value = Convert.ToString(_noRange);
            _gridView[3, _gridView.Rows.Count - 1].Value = Convert.ToString(_noTriggered);
            _gridView[4, _gridView.Rows.Count - 1].Value = Convert.ToString(_profitOrders);
            _gridView[5, _gridView.Rows.Count - 1].Value = Convert.ToString(_lossOrders);
            _gridView[6, _gridView.Rows.Count - 1].Value = Convert.ToString(_totalResult);
        }
    }
}
