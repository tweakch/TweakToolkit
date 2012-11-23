using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Domain;

namespace TweakToolkit.Bloomberg.Wrapper
{
    public class ReferenceDataRequestInfo
    {
        public ReferenceDataRequestInfo(IEnumerable<string> tickers, IEnumerable<string> fields)
        {
            Id = new CorrelationID();
            Tickers = new List<string>(tickers);
            Fields = new List<string>(fields);
            Response = new ReferenceDataResponse(this);
        }

        public CorrelationID Id { get; private set; }

        public List<string> Fields { get; private set; }

        public List<string> Tickers { get; private set; }

        public ReferenceDataResponse Response { get; private set; }

        public Action<ReferenceDataResponse> Callback { get; set; }
    }
}