/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;

namespace StockSim.messages
{
    class UpdatePortfolioMessage
    {
        public UpdatePortfolioMessage(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            Contract = contract;
            Position = position;
            MarketPrice = marketPrice;
            MarketValue = marketValue;
            AverageCost = averageCost;
            UnrealizedPNL = unrealizedPNL;
            RealizedPNL = realizedPNL;
            AccountName = accountName;
        }

        public Contract Contract { get; set; }

        public double Position { get; set; }

        public double MarketPrice { get; set; }

        public double MarketValue { get; set; }

        public double AverageCost { get; set; }

        public double UnrealizedPNL { get; set; }

        public double RealizedPNL { get; set; }

        public string AccountName { get; set; }
    }
}
