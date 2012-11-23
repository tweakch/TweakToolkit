using System;

namespace TweakToolkit.Bloomberg
{
    public class PriceInfo
    {
        public PriceInfo(double? bid, double? ask, DateTime? lastChangeBid, DateTime? lastChangeAsk)
        {
            Bid = bid;
            Ask = ask;
            LastChangeAsk = lastChangeAsk;
            LastChangeBid = LastChangeBid;
        }

        public double? Bid { get; set; }

        public double? Ask { get; set; }

        public DateTime? LastChangeBid { get; set; }

        public DateTime? LastChangeAsk { get; set; }
    }
}