/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System.Collections.Generic;
using System.Windows.Forms;
using System;
using IBApi;
using StockSim.messages;
using StockSim.util;
using StockSim.types;

namespace StockSim.ui
{
    class MarketDataManager : DataManager
    {
        public const int TICK_ID_BASE = 10000000;
        
        private const int CHECKBOX_INDEX = 0;
        private const int DESCRIPTION_INDEX = 1;

        private const int BID_PRICE_INDEX = 2;
        private const int ASK_PRICE_INDEX = 3;

        private bool active;

        private List<Contract> activeRequests = new List<Contract>();

        public MarketDataManager(IBClient client, DataGridView dataGrid)
            : base(client, dataGrid)
        {
        }

        public bool isActive() { return active; }
        public void setActive() { active = true; }
        public void unsetActive() { active = false; }

        public void AddRequest(Contract contract, string genericTickList)
        {
            activeRequests.Add(contract);
            int nextReqId = TICK_ID_BASE + (currentTicker++);
            checkToAddRow(nextReqId);
            ibClient.ClientSocket.reqMktData(nextReqId, contract, genericTickList, false, false, new List<TagValue>());

            if (!uiControl.Visible)
                uiControl.Visible = true;
        }

        public void RequestMarketDataType(int marketDataType)
        {
            ibClient.ClientSocket.reqMarketDataType(marketDataType);
        }

        public override void NotifyError(int requestId)
        {
            //activeRequests.RemoveAt(GetIndex(requestId));
            //currentTicker-=1;
        }

        public override void Clear()
        {
            ((DataGridView)uiControl).Rows.Clear();
            activeRequests.Clear();
            uiControl.Visible = false;
            currentTicker = 1;
        }

        public void StopActiveRequests(bool clearTable)
        {
            for (int i = 1; i < currentTicker; i++)
            {
                ibClient.ClientSocket.cancelMktData(i + TICK_ID_BASE);
            }
            if (clearTable)
                Clear();
        }

        private void checkToAddRow(int requestId)
        {
            DataGridView grid = (DataGridView)uiControl;
            if (grid.Rows.Count < (requestId - TICK_ID_BASE))
            {
                grid.Rows.Add(true, GetIndex(requestId), -1, -1);
                grid[DESCRIPTION_INDEX, GetIndex(requestId)].Value = Utils.ContractToString(activeRequests[GetIndex(requestId)]);
                //grid[MARKET_DATA_TYPE_INDEX, GetIndex(requestId)].Value = MarketDataType.Real_Time.Name; // default
            }
        }

        private int GetIndex(int requestId)
        {
            return requestId - TICK_ID_BASE - 1;
        }

        public void HandleMarketDataTypeMessage(MarketDataTypeMessage dataMessage)
        {
            //DataGridView grid = (DataGridView)uiControl;

            //grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.get(dataMessage.MarketDataType).Name;
        }

        public bool IsUIUpdateRequired(MarketDataMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            return grid.Rows.Count >= dataMessage.RequestId - TICK_ID_BASE;
        }

        public List<string> SelectedSymbols()
        {
            List<string> result = new List<string>();
            DataGridView grid = (DataGridView)uiControl;
            for (var i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid[CHECKBOX_INDEX, i].Value) == false) continue;
                string symbol = Convert.ToString(grid[DESCRIPTION_INDEX, i].Value);
                var syms = symbol.Split(' ');
                if (syms.Length <= 0) continue;
                result.Add(syms[0]);
            }
            return result;
        }

        public void UpdateUI(TickPriceMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            /*if ((grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value.Equals(MarketDataType.Real_Time.Name)) &&
                (dataMessage.Field == TickType.DELAYED_BID ||
                dataMessage.Field == TickType.DELAYED_ASK ||
                dataMessage.Field == TickType.DELAYED_CLOSE ||
                dataMessage.Field == TickType.DELAYED_OPEN ||
                dataMessage.Field == TickType.DELAYED_LAST ||
                dataMessage.Field == TickType.DELAYED_HIGH ||
                dataMessage.Field == TickType.DELAYED_LOW))
            {
                grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.Delayed.Name;
            }*/

            switch (dataMessage.Field)
            {
                case TickType.BID:
                case TickType.DELAYED_BID:
                    {
                        //BID, DELAYED_BID
                        grid[BID_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        //grid[PRE_OPEN_BID, GetIndex(dataMessage.RequestId)].Value = dataMessage.Attribs.PreOpen;
                        break;
                    }
                case TickType.ASK:
                case TickType.DELAYED_ASK:
                    {
                        //ASK, DELAYED_ASK
                        grid[ASK_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        //grid[PRE_OPEN_ASK, GetIndex(dataMessage.RequestId)].Value = dataMessage.Attribs.PreOpen;
                        break;
                    }
                    /*
                case TickType.CLOSE:
                case TickType.DELAYED_CLOSE:
                    {
                        //CLOSE, DELAYED_CLOSE
                        grid[CLOSE_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case TickType.OPEN:
                case TickType.DELAYED_OPEN:
                    {
                        //OPEN, DELAYED_OPEN
                        grid[OPEN_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case TickType.LAST:
                case TickType.DELAYED_LAST:
                    {
                        //LAST, DELAYED_LAST
                        grid[LAST_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case TickType.HIGH:
                case TickType.DELAYED_HIGH:
                    {
                        //HIGH, DELAYED_HIGH
                        grid[HIGH_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case TickType.LOW:
                case TickType.DELAYED_LOW:
                    {
                        //LOW, DELAYED_LOW
                        grid[LOW_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }*/
            }
        }

        public void UpdateUI(TickSizeMessage dataMessage)
        {
            /*DataGridView grid = (DataGridView)uiControl;

            if ((grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value.Equals(MarketDataType.Real_Time.Name)) &&
                (dataMessage.Field == TickType.DELAYED_BID_SIZE ||
                dataMessage.Field == TickType.DELAYED_ASK_SIZE ||
                dataMessage.Field == TickType.DELAYED_LAST_SIZE ||
                dataMessage.Field == TickType.DELAYED_VOLUME))
            {
                grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.Delayed.Name;
            }
            switch (dataMessage.Field)
            {
                case TickType.BID_SIZE:
                case TickType.DELAYED_BID_SIZE:
                    {
                        //BID SIZE, DELAYED_BID_SIZE
                        grid[BID_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.ASK_SIZE:
                case TickType.DELAYED_ASK_SIZE:
                    {
                        //ASK SIZE, DELAYED_ASK_SIZE
                        grid[ASK_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.LAST_SIZE:
                case TickType.DELAYED_LAST_SIZE:
                    {
                        //LAST_SIZE, DELAYED_LAST_SIZE
                        grid[LAST_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.VOLUME:
                case TickType.DELAYED_VOLUME:
                    {
                        //VOLUME, DELAYED_VOLUME
                        grid[VOLUME_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.FUTURES_OPEN_INTEREST:
                    {
                        //FUTURES_OPEN_INTEREST
                        grid[FUTURES_OPEN_INTEREST_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.AVG_OPT_VOLUME:
                    {
                        //AVG_OPT_VOLUME
                        grid[AVG_OPT_VOLUME_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case TickType.SHORTABLE_SHARES:
                    {
                        //SHORTABLE_SHARES
                        grid[SHORTABLE_SHARES_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
            }*/
        }

    }

}


