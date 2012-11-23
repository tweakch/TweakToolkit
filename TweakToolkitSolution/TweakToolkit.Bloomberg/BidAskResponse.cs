using System;
using System.Collections.Generic;
using TweakToolkit.Bloomberg.Domain;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg
{
    public class BidAskResponse
    {
        private readonly ReferenceDataResponse response;

        private readonly Dictionary<string, PriceInfo> tickerPriceCollection;

        public BidAskResponse(ReferenceDataResponse response)
        {
            tickerPriceCollection = new Dictionary<string, PriceInfo>();
            this.response = response;
            ParseResponse();
        }

        public bool HasError { get; set; }

        private void ParseResponse()
        {
            foreach (var securityData in response.Securities)
            {
                try
                {
                    double bid = default(double);
                    double ask = default(double);
                    DateTime? time = null;

                    string sec = securityData.Key;
                    SecurityData requestedData = securityData.Value;
                    Dictionary<string, FieldData> fields = requestedData.Fields;

                    if (fields.ContainsKey(Settings.Default.Bloomberg_Field_Bid))
                    {
                        FieldData bidField = fields[Settings.Default.Bloomberg_Field_Bid];
                        if ((bidField != null) && (bidField.HasValue))
                            bid = bidField.GetValueAsDouble();
                    }

                    if (fields.ContainsKey(Settings.Default.Bloomberg_Field_Ask))
                    {
                        FieldData askField = fields[Settings.Default.Bloomberg_Field_Ask];
                        if ((askField != null) && (askField.HasValue))
                            ask = askField.GetValueAsDouble();
                    }

                    if (fields.ContainsKey(Settings.Default.Bloomberg_Field_Time))
                    {
                        FieldData timeField = fields[Settings.Default.Bloomberg_Field_Time];
                        if ((timeField != null) && (timeField.HasValue))
                            time = timeField.GetValueAsDateTime();
                    }
                    if (time == null) time = new DateTime(1900, 1, 1);
                    tickerPriceCollection.Add(sec, new PriceInfo(bid, ask, time, time));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ParseResponse() " + ex);
                    HasError = true;
                }
            }
        }

        public DateTime? GetLastPriceChange(string ticker)
        {
            if (tickerPriceCollection.ContainsKey(ticker))
            {
                DateTime? bidUpdate = tickerPriceCollection[ticker].LastChangeBid;
                DateTime? askUpdate = tickerPriceCollection[ticker].LastChangeAsk;
                DateTime? lastChange = bidUpdate > askUpdate ? bidUpdate : askUpdate;
                return lastChange;
            }
            return null;
        }

        public double? GetBid(string ticker)
        {
            return tickerPriceCollection.ContainsKey(ticker) ? tickerPriceCollection[ticker].Bid : null;
        }

        public double? GetAsk(string ticker)
        {
            if (tickerPriceCollection.ContainsKey(ticker))
            {
                return tickerPriceCollection[ticker].Ask;
            }
            return null;
        }
    }
}