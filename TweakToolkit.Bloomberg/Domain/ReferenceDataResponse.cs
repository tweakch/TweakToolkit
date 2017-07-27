using System;
using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg.Domain
{
    public class ReferenceDataResponse
    {
        private Message _response;

        public ReferenceDataResponse(ReferenceDataRequestInfo info)
        {
            Info = info;
            CorrelationID = info.Id;
            InitializeResponse();
        }

        public BloombergSessionWrapper Session { get; set; }

        public CorrelationID CorrelationID { get; set; }

        public Dictionary<string, SecurityData> Securities { get; set; }

        public List<String> Fields { get; set; }

        public Boolean HasArrivedCompletely
        {
            get { return !Securities.Values.Contains(null); }
        }

        private ReferenceDataRequestInfo Info { get; set; }

        private void InitializeResponse()
        {
            Securities = new Dictionary<string, SecurityData>(Info.Tickers.Count);

            foreach (string security in Info.Tickers)
            {
                Securities.Add(security, null);
            }

            Fields = new List<String>(Info.Fields.AsEnumerable());
        }

        public void SaveMessage(Message response)
        {
            ValidateResponse(response);
            InitializeSecurites();
        }

        private void InitializeSecurites()
        {
            Element _securityDataArray = _response.GetElement("securityData");
            try
            {
                for (int i = 0; i < _securityDataArray.NumValues; i++)
                {
                    var data = new SecurityData(this, _securityDataArray.GetValueAsElement(i));
                    Securities[data.Security] = data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InitializeSecurites() " + ex);
            }
        }

        private void ValidateResponse(Message response)
        {
            if (response.CorrelationID != CorrelationID)
            {
                throw new Exception("correlationIDs must match in order to save messages on a response.");
            }

            if (response.HasElement("responseError"))
            {
                throw new Exception("responseError");
            }
            _response = response;
        }

        public override string ToString()
        {
            return _response.ToString();
        }

        public ReferenceDataRequestInfo GetDescription()
        {
            return Info;
        }
    }
}