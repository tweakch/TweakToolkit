using System;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class PriceWebsiteDescription
    {
        public PriceWebsiteDescription()
        {
            Valor = 123456789;
            LastUpdated = DateTime.Now;
            Bid = 100;
            Ask = 101;
        }

        public double Ask { get; private set; }

        public double Bid { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public int Valor { get; private set; }
    }
}