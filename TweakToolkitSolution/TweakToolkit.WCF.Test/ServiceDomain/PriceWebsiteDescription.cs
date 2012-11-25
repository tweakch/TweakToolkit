using System;
using TweakToolkit.EntityFramework.WebsiteData;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class PriceWebsiteDescription
    {
        public PriceWebsiteDescription(PriceWebsiteData data)
        {
            Valor = data.Valor;
            LastUpdated = data.UpdatedOn.GetValueOrDefault(new DateTime(1900, 1, 1));
            Bid = data.Bid.GetValueOrDefault();
            Ask = data.Ask.GetValueOrDefault();
        }

        public double Ask { get; private set; }

        public double Bid { get; private set; }

        public DateTime LastUpdated { get; private set; }

        public int Valor { get; private set; }
    }
}