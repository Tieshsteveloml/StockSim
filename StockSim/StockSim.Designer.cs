
namespace StockSim
{
    partial class StockSim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXT_HOST = new System.Windows.Forms.TextBox();
            this.TXT_PORT = new System.Windows.Forms.TextBox();
            this.TXT_CLIENTID = new System.Windows.Forms.TextBox();
            this.BTN_CONNECT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DG_STOCKS = new System.Windows.Forms.DataGridView();
            this.DGC_SELECT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGC_SYMBOL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGC_BID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGC_ASK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GB_SETTINGS = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TXT_TAKEPROFIT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXT_STOPLOSS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_DURATION = new System.Windows.Forms.ComboBox();
            this.TXT_DURATION = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TXT_RANGE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTN_BACKTEST = new System.Windows.Forms.Button();
            this.BTN_AUTOTRADE = new System.Windows.Forms.Button();
            this.LA_STATUS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DG_RESULT = new System.Windows.Forms.DataGridView();
            this.DGCR_REPORTTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_SYMBOL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_NORANGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_NOTTRIGGERED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_PROFITORDERS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_LOSSORDERS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCR_RESULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DG_STOCKS)).BeginInit();
            this.GB_SETTINGS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_RESULT)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXT_HOST
            // 
            this.TXT_HOST.Location = new System.Drawing.Point(961, 25);
            this.TXT_HOST.Name = "TXT_HOST";
            this.TXT_HOST.Size = new System.Drawing.Size(135, 20);
            this.TXT_HOST.TabIndex = 0;
            this.TXT_HOST.Text = "127.0.0.1";
            // 
            // TXT_PORT
            // 
            this.TXT_PORT.Location = new System.Drawing.Point(1171, 25);
            this.TXT_PORT.Name = "TXT_PORT";
            this.TXT_PORT.Size = new System.Drawing.Size(100, 20);
            this.TXT_PORT.TabIndex = 1;
            this.TXT_PORT.Text = "7496";
            // 
            // TXT_CLIENTID
            // 
            this.TXT_CLIENTID.Location = new System.Drawing.Point(1346, 25);
            this.TXT_CLIENTID.Name = "TXT_CLIENTID";
            this.TXT_CLIENTID.Size = new System.Drawing.Size(100, 20);
            this.TXT_CLIENTID.TabIndex = 2;
            this.TXT_CLIENTID.Text = "1";
            // 
            // BTN_CONNECT
            // 
            this.BTN_CONNECT.Location = new System.Drawing.Point(1479, 21);
            this.BTN_CONNECT.Name = "BTN_CONNECT";
            this.BTN_CONNECT.Size = new System.Drawing.Size(94, 23);
            this.BTN_CONNECT.TabIndex = 3;
            this.BTN_CONNECT.Text = "Connect";
            this.BTN_CONNECT.UseVisualStyleBackColor = true;
            this.BTN_CONNECT.Click += new System.EventHandler(this.BTN_CONNECT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(928, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1141, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1297, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Client Id";
            // 
            // DG_STOCKS
            // 
            this.DG_STOCKS.AllowUserToAddRows = false;
            this.DG_STOCKS.AllowUserToDeleteRows = false;
            this.DG_STOCKS.AllowUserToResizeRows = false;
            this.DG_STOCKS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_STOCKS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGC_SELECT,
            this.DGC_SYMBOL,
            this.DGC_BID,
            this.DGC_ASK});
            this.DG_STOCKS.EnableHeadersVisualStyles = false;
            this.DG_STOCKS.Location = new System.Drawing.Point(23, 21);
            this.DG_STOCKS.Name = "DG_STOCKS";
            this.DG_STOCKS.RowHeadersVisible = false;
            this.DG_STOCKS.Size = new System.Drawing.Size(363, 661);
            this.DG_STOCKS.TabIndex = 7;
            // 
            // DGC_SELECT
            // 
            this.DGC_SELECT.HeaderText = "...";
            this.DGC_SELECT.MinimumWidth = 25;
            this.DGC_SELECT.Name = "DGC_SELECT";
            this.DGC_SELECT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGC_SELECT.Width = 25;
            // 
            // DGC_SYMBOL
            // 
            this.DGC_SYMBOL.HeaderText = "Symbol";
            this.DGC_SYMBOL.MinimumWidth = 100;
            this.DGC_SYMBOL.Name = "DGC_SYMBOL";
            this.DGC_SYMBOL.ReadOnly = true;
            this.DGC_SYMBOL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGC_SYMBOL.Width = 135;
            // 
            // DGC_BID
            // 
            this.DGC_BID.HeaderText = "Bid";
            this.DGC_BID.MinimumWidth = 50;
            this.DGC_BID.Name = "DGC_BID";
            this.DGC_BID.ReadOnly = true;
            this.DGC_BID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DGC_ASK
            // 
            this.DGC_ASK.HeaderText = "Ask";
            this.DGC_ASK.MinimumWidth = 50;
            this.DGC_ASK.Name = "DGC_ASK";
            this.DGC_ASK.ReadOnly = true;
            this.DGC_ASK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GB_SETTINGS
            // 
            this.GB_SETTINGS.Controls.Add(this.label10);
            this.GB_SETTINGS.Controls.Add(this.label9);
            this.GB_SETTINGS.Controls.Add(this.TXT_TAKEPROFIT);
            this.GB_SETTINGS.Controls.Add(this.label8);
            this.GB_SETTINGS.Controls.Add(this.TXT_STOPLOSS);
            this.GB_SETTINGS.Controls.Add(this.label7);
            this.GB_SETTINGS.Controls.Add(this.CB_DURATION);
            this.GB_SETTINGS.Controls.Add(this.TXT_DURATION);
            this.GB_SETTINGS.Controls.Add(this.label4);
            this.GB_SETTINGS.Controls.Add(this.label6);
            this.GB_SETTINGS.Controls.Add(this.TXT_RANGE);
            this.GB_SETTINGS.Controls.Add(this.label5);
            this.GB_SETTINGS.Location = new System.Drawing.Point(397, 63);
            this.GB_SETTINGS.Name = "GB_SETTINGS";
            this.GB_SETTINGS.Size = new System.Drawing.Size(1176, 89);
            this.GB_SETTINGS.TabIndex = 8;
            this.GB_SETTINGS.TabStop = false;
            this.GB_SETTINGS.Text = "Settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1093, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(866, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "%";
            // 
            // TXT_TAKEPROFIT
            // 
            this.TXT_TAKEPROFIT.Location = new System.Drawing.Point(988, 42);
            this.TXT_TAKEPROFIT.Name = "TXT_TAKEPROFIT";
            this.TXT_TAKEPROFIT.Size = new System.Drawing.Size(100, 20);
            this.TXT_TAKEPROFIT.TabIndex = 9;
            this.TXT_TAKEPROFIT.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(922, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Take Profit";
            // 
            // TXT_STOPLOSS
            // 
            this.TXT_STOPLOSS.Location = new System.Drawing.Point(760, 42);
            this.TXT_STOPLOSS.Name = "TXT_STOPLOSS";
            this.TXT_STOPLOSS.Size = new System.Drawing.Size(100, 20);
            this.TXT_STOPLOSS.TabIndex = 7;
            this.TXT_STOPLOSS.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(699, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Stop Loss";
            // 
            // CB_DURATION
            // 
            this.CB_DURATION.FormattingEnabled = true;
            this.CB_DURATION.Items.AddRange(new object[] {
            "D",
            "M",
            "Y"});
            this.CB_DURATION.Location = new System.Drawing.Point(512, 41);
            this.CB_DURATION.Name = "CB_DURATION";
            this.CB_DURATION.Size = new System.Drawing.Size(103, 21);
            this.CB_DURATION.TabIndex = 5;
            this.CB_DURATION.Text = "M";
            // 
            // TXT_DURATION
            // 
            this.TXT_DURATION.Location = new System.Drawing.Point(390, 42);
            this.TXT_DURATION.Name = "TXT_DURATION";
            this.TXT_DURATION.Size = new System.Drawing.Size(119, 20);
            this.TXT_DURATION.TabIndex = 4;
            this.TXT_DURATION.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "%";
            // 
            // TXT_RANGE
            // 
            this.TXT_RANGE.Location = new System.Drawing.Point(127, 42);
            this.TXT_RANGE.Name = "TXT_RANGE";
            this.TXT_RANGE.Size = new System.Drawing.Size(134, 20);
            this.TXT_RANGE.TabIndex = 1;
            this.TXT_RANGE.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Range";
            // 
            // BTN_BACKTEST
            // 
            this.BTN_BACKTEST.Location = new System.Drawing.Point(66, 689);
            this.BTN_BACKTEST.Name = "BTN_BACKTEST";
            this.BTN_BACKTEST.Size = new System.Drawing.Size(270, 24);
            this.BTN_BACKTEST.TabIndex = 10;
            this.BTN_BACKTEST.Text = "BackTest";
            this.BTN_BACKTEST.UseVisualStyleBackColor = true;
            this.BTN_BACKTEST.Click += new System.EventHandler(this.BTN_BACKTEST_Click);
            // 
            // BTN_AUTOTRADE
            // 
            this.BTN_AUTOTRADE.Location = new System.Drawing.Point(224, 689);
            this.BTN_AUTOTRADE.Name = "BTN_AUTOTRADE";
            this.BTN_AUTOTRADE.Size = new System.Drawing.Size(112, 24);
            this.BTN_AUTOTRADE.TabIndex = 11;
            this.BTN_AUTOTRADE.Text = "AutoTrade";
            this.BTN_AUTOTRADE.UseVisualStyleBackColor = true;
            this.BTN_AUTOTRADE.Visible = false;
            // 
            // LA_STATUS
            // 
            this.LA_STATUS.AutoSize = true;
            this.LA_STATUS.Location = new System.Drawing.Point(437, 696);
            this.LA_STATUS.Name = "LA_STATUS";
            this.LA_STATUS.Size = new System.Drawing.Size(79, 13);
            this.LA_STATUS.TabIndex = 13;
            this.LA_STATUS.Text = "Disconnected..";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DG_RESULT);
            this.groupBox1.Location = new System.Drawing.Point(397, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1176, 361);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // DG_RESULT
            // 
            this.DG_RESULT.AllowUserToAddRows = false;
            this.DG_RESULT.AllowUserToDeleteRows = false;
            this.DG_RESULT.AllowUserToResizeRows = false;
            this.DG_RESULT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_RESULT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCR_REPORTTIME,
            this.DGCR_SYMBOL,
            this.DGCR_NORANGE,
            this.DGCR_NOTTRIGGERED,
            this.DGCR_PROFITORDERS,
            this.DGCR_LOSSORDERS,
            this.DGCR_RESULT});
            this.DG_RESULT.EnableHeadersVisualStyles = false;
            this.DG_RESULT.Location = new System.Drawing.Point(0, 20);
            this.DG_RESULT.Name = "DG_RESULT";
            this.DG_RESULT.RowHeadersVisible = false;
            this.DG_RESULT.Size = new System.Drawing.Size(1176, 341);
            this.DG_RESULT.TabIndex = 0;
            // 
            // DGCR_REPORTTIME
            // 
            this.DGCR_REPORTTIME.HeaderText = "Report Time";
            this.DGCR_REPORTTIME.Name = "DGCR_REPORTTIME";
            this.DGCR_REPORTTIME.ReadOnly = true;
            this.DGCR_REPORTTIME.Width = 200;
            // 
            // DGCR_SYMBOL
            // 
            this.DGCR_SYMBOL.HeaderText = "Symbol";
            this.DGCR_SYMBOL.MinimumWidth = 50;
            this.DGCR_SYMBOL.Name = "DGCR_SYMBOL";
            this.DGCR_SYMBOL.ReadOnly = true;
            this.DGCR_SYMBOL.Width = 200;
            // 
            // DGCR_NORANGE
            // 
            this.DGCR_NORANGE.HeaderText = "Total NoRange";
            this.DGCR_NORANGE.MinimumWidth = 50;
            this.DGCR_NORANGE.Name = "DGCR_NORANGE";
            this.DGCR_NORANGE.ReadOnly = true;
            this.DGCR_NORANGE.Width = 160;
            // 
            // DGCR_NOTTRIGGERED
            // 
            this.DGCR_NOTTRIGGERED.HeaderText = "Total NoTriggered";
            this.DGCR_NOTTRIGGERED.MinimumWidth = 50;
            this.DGCR_NOTTRIGGERED.Name = "DGCR_NOTTRIGGERED";
            this.DGCR_NOTTRIGGERED.ReadOnly = true;
            this.DGCR_NOTTRIGGERED.Width = 160;
            // 
            // DGCR_PROFITORDERS
            // 
            this.DGCR_PROFITORDERS.HeaderText = "Total ProfitOrders";
            this.DGCR_PROFITORDERS.MinimumWidth = 50;
            this.DGCR_PROFITORDERS.Name = "DGCR_PROFITORDERS";
            this.DGCR_PROFITORDERS.ReadOnly = true;
            this.DGCR_PROFITORDERS.Width = 160;
            // 
            // DGCR_LOSSORDERS
            // 
            this.DGCR_LOSSORDERS.HeaderText = "Total LossOrders";
            this.DGCR_LOSSORDERS.MinimumWidth = 50;
            this.DGCR_LOSSORDERS.Name = "DGCR_LOSSORDERS";
            this.DGCR_LOSSORDERS.ReadOnly = true;
            this.DGCR_LOSSORDERS.Width = 160;
            // 
            // DGCR_RESULT
            // 
            this.DGCR_RESULT.HeaderText = "Total Result(%)";
            this.DGCR_RESULT.MinimumWidth = 50;
            this.DGCR_RESULT.Name = "DGCR_RESULT";
            this.DGCR_RESULT.ReadOnly = true;
            this.DGCR_RESULT.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.messageBox);
            this.groupBox2.Location = new System.Drawing.Point(397, 525);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1176, 157);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Messages";
            // 
            // messageBox
            // 
            this.messageBox.AcceptsReturn = true;
            this.messageBox.Location = new System.Drawing.Point(0, 20);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(1176, 137);
            this.messageBox.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(397, 696);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Status:";
            // 
            // StockSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1598, 724);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LA_STATUS);
            this.Controls.Add(this.BTN_AUTOTRADE);
            this.Controls.Add(this.BTN_BACKTEST);
            this.Controls.Add(this.GB_SETTINGS);
            this.Controls.Add(this.DG_STOCKS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_CONNECT);
            this.Controls.Add(this.TXT_CLIENTID);
            this.Controls.Add(this.TXT_PORT);
            this.Controls.Add(this.TXT_HOST);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StockSim";
            this.Text = "StockSim";
            this.Load += new System.EventHandler(this.StockSim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_STOCKS)).EndInit();
            this.GB_SETTINGS.ResumeLayout(false);
            this.GB_SETTINGS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_RESULT)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_HOST;
        private System.Windows.Forms.TextBox TXT_PORT;
        private System.Windows.Forms.TextBox TXT_CLIENTID;
        private System.Windows.Forms.Button BTN_CONNECT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DG_STOCKS;
        private System.Windows.Forms.GroupBox GB_SETTINGS;
        private System.Windows.Forms.Button BTN_BACKTEST;
        private System.Windows.Forms.Button BTN_AUTOTRADE;
        private System.Windows.Forms.Label LA_STATUS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXT_RANGE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DG_RESULT;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGC_SELECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGC_SYMBOL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGC_BID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGC_ASK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TXT_TAKEPROFIT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXT_STOPLOSS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CB_DURATION;
        private System.Windows.Forms.TextBox TXT_DURATION;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_REPORTTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_SYMBOL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_NORANGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_NOTTRIGGERED;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_PROFITORDERS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_LOSSORDERS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCR_RESULT;
    }
}

