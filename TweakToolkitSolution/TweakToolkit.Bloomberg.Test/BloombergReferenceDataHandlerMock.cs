using System.Collections.Generic;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg.Test
{
    public class BloombergReferenceDataHandlerMock
    {
        public BloombergReferenceDataHandlerMock(string referenceDataResponse)
        {
            Tickers = new List<string>();
            Fields = new List<string>();
        }

        public ReferenceDataRequestInfo RequestInfo
        {
            get { return new ReferenceDataRequestInfo(Tickers, Fields); }
        }

        public List<string> Fields { get; private set; }

        public List<string> Tickers { get; private set; }

        public void AddField(string field)
        {
            Fields.Add(field);
        }

        public void AddSecurity(string security)
        {
            Tickers.Add(security);
        }
    }
}