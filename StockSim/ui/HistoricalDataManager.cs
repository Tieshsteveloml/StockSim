/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
//using System.Windows.Forms.DataVisualization.Charting;
using IBApi;
using StockSim.messages;
using System.Globalization;
using System.Windows.Forms;

namespace StockSim.ui
{
    class HistoricalDataManager : DataManager
    {
        public const int HISTORICAL_ID_BASE = 30000000;

        private string fullDatePattern = "yyyyMMdd  HH:mm:ss";
        private string yearMonthDayPattern = "yyyyMMdd";

        protected int barCounter = -1;
        protected DataGridView gridView;

        private Dictionary<int, StrategyManager> _strategies;

        public HistoricalDataManager(IBClient ibClient, Control chart, DataGridView gridView) : base(ibClient, chart) 
        {
            /*Chart historicalChart = (Chart)uiControl;
            historicalChart.Series[0]["PriceUpColor"] = "Green";
            historicalChart.Series[0]["PriceDownColor"] = "Red";*/
            this.gridView = gridView;
            _strategies = new Dictionary<int, StrategyManager>();
        }

        public void AddRequest(Contract contract, int nConId, string endDateTime, string durationString, string barSizeSetting, string whatToShow, int useRTH, int dateFormat, bool keepUpToDate, double range, double stoploss, double takeprofit)
        {
            int reqId = currentTicker + HISTORICAL_ID_BASE + nConId;
            _strategies[reqId] = new StrategyManager(contract, range, stoploss, takeprofit, gridView);
            ibClient.ClientSocket.reqHistoricalData(reqId, contract, endDateTime, durationString, barSizeSetting, whatToShow, useRTH, 1, keepUpToDate, new List<TagValue>());
        }

        public override void Clear()
        {
            barCounter = -1;
            _strategies.Clear();
            /*Chart historicalChart = (Chart)uiControl;
            historicalChart.Series[0].Points.Clear();*/
            gridView.Rows.Clear();
        }

        public override void NotifyError(int requestId)
        {
        }

        public void UpdateUI(HistoricalDataMessage message)
        {
            _strategies[message.RequestId].AddBar(message);
        }

        public void UpdateUI(HistoricalDataEndMessage message)
        {
            Strategy(message.RequestId);
        }

        private void Strategy(int reqId)
        {
            if (!_strategies.ContainsKey(reqId)) return;
            _strategies[reqId].Strategy();
        }

        private void PaintChart()
        {
            /*
            DateTime dt;
            Chart historicalChart = (Chart)uiControl;
            for (int i = 0; i < historicalData.Count; i++)
            {
                if (historicalData[i].Date.Length == fullDatePattern.Length)
                    DateTime.TryParseExact(historicalData[i].Date, fullDatePattern, null, DateTimeStyles.None, out dt);
                else if (historicalData[i].Date.Length == yearMonthDayPattern.Length)
                    DateTime.TryParseExact(historicalData[i].Date, yearMonthDayPattern, null, DateTimeStyles.None, out dt);
                else
                    continue;

                // adding date and high
                historicalChart.Series[0].Points.AddXY(dt, historicalData[i].High);
                // adding low
                historicalChart.Series[0].Points[i].YValues[1] = historicalData[i].Low;
                //adding open
                historicalChart.Series[0].Points[i].YValues[2] = historicalData[i].Open;
                // adding close
                historicalChart.Series[0].Points[i].YValues[3] = historicalData[i].Close;
                PopulateGrid(historicalData[i]);
            }*/
        }
    }
}
