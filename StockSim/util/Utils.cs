/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;

using IBApi;

namespace StockSim.util
{
    class Utils
    {
        public static string UnixMillisecondsToString(long milliseconds, string dateFormat)
        {
            return string.Format("{0:" + dateFormat + "}", DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).AddMilliseconds(milliseconds));
        }

        public static string ContractToString(Contract contract)
        {
            return contract.Symbol + " " + contract.SecType + " " + contract.Currency + " @ " + contract.Exchange;
        }

        public static bool ContractsAreEqual(Contract contractA, Contract contractB)
        {
            if (contractA.Symbol.Equals(contractB.Symbol) && contractA.SecType.Equals(contractB.SecType) && contractA.Currency.Equals(contractB.Currency))
            {
                if (contractA.LastTradeDateOrContractMonth != null && contractB.LastTradeDateOrContractMonth != null)
                {
                    if (contractA.LastTradeDateOrContractMonth.Equals(contractB.LastTradeDateOrContractMonth))
                    {
                        if (contractA.Multiplier != null && contractB.Multiplier != null)
                        {
                            return contractA.Multiplier.Equals(contractB.Multiplier);
                        }
                        else
                            return true;
                    }
                }
                else
                    return true;
            }

            return false;
        }
        public static int DateToInt(DateTime date)
        {
            var sdate = date.ToString("yyyyMMdd");
            return Convert.ToInt32(sdate);
        }

        public static bool IsMatchedTime(DateTime date, string time)
        {
            var sdate = date.ToString("yyyyMMdd  HH:mm:ss");
            if (sdate.Contains(time)) return true;
            return false;
        }
        public static bool IsInTime(DateTime date, string begin, string end)
        {
            var bgs = begin.Split(':');
            if (bgs.Length != 2) return false;
            int bh = Convert.ToInt32(bgs[0]);
            int bm = Convert.ToInt32(bgs[1]);

            var ends = end.Split(':');
            if (ends.Length != 2) return false;
            int eh = Convert.ToInt32(ends[0]);
            int em = Convert.ToInt32(ends[1]);
            if (date.Hour < bh || date.Hour > eh) return false;
            if (date.Hour == bh && date.Minute < bm) return false;
            if (date.Hour == eh && date.Minute > em) return false;
            return true;
        }

        public static DateTime S2Date(string sdate)
        {
            return DateTime.ParseExact(sdate, "yyyyMMdd  HH:mm:ss", null);
        }
        public static DateTime LocalToAnyTimezone(string sdate, TimeZoneInfo zone)
        {
            var ltime = S2Date(sdate);
            var utime = ltime.ToUniversalTime();
            var etime = TimeZoneInfo.ConvertTimeFromUtc(utime, zone);
            return etime;
        }
    }
}
