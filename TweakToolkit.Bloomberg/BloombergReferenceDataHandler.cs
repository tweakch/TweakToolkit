using System;
using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Domain;
using TweakToolkit.Bloomberg.Wrapper;
using TweakToolkit.Bloomberg.Wrapper.EventHandler;

namespace TweakToolkit.Bloomberg
{
    public class BloombergReferenceDataHandler : RequestHandlerBase<BloombergReferenceDataHandler>
    {
        public BloombergReferenceDataHandler()
            : base(DataService.ReferenceData)
        {
        }

        public bool IsWaitingForResponse { get; set; }

        public IParseSessionMessages RequestResults { get; set; }

        public static void FillRequest(Request request, ReferenceDataRequestInfo desc)
        {
            Element securities = request.GetElement("securities");
            Element fields = request.GetElement("fields");
            foreach (string security in desc.Tickers)
            {
                securities.AppendValue(security);
            }
            foreach (string field in desc.Fields)
            {
                fields.AppendValue(field);
            }
        }

        public override void Clear()
        {
            Fields.Clear();
            Securities.Clear();
        }

        public ReferenceDataResponse GetResponse(CorrelationID correlationId)
        {
            return SessionWrapper.RequestDescriptions.Values.First(info => info.Id.Equals(correlationId)).Response;
        }

        public SecurityData GetSecurityData(string issuerTicker)
        {
            ReferenceDataResponse response =
                SessionWrapper.RequestDescriptions.Values.First(info => info.Tickers.Contains(issuerTicker)).Response;

            SecurityData securityData =
                response.Securities.Select(kvp => kvp.Value).First(data => data.Security.Equals(issuerTicker));

            return securityData;
        }

        public override bool ParseCommandLine(string[] args)
        {
            throw new NotImplementedException();
        }

        public override void PrintUsage()
        {
            throw new NotImplementedException();
        }

        public override CorrelationID SendRequestAsync()
        {
            Request request;
            ReferenceDataRequestInfo info = RegisterNewRequest(out request);

            Console.WriteLine("Sending Request: " + request);
            SessionWrapper.RequestDescriptions.Add(info.Id, info);
            SessionWrapper.SendRequestAsync(request, info.Id);
            return info.Id;
        }

        public void SendRequestAsync(Action<ReferenceDataResponse> callback)
        {
            Request request;
            ReferenceDataRequestInfo info = RegisterNewAsyncRequest(out request, callback);
            SessionWrapper.RequestDescriptions.Add(info.Id, info);
            SessionWrapper.SendRequestAsync(request, info.Id);
        }

        protected override void RegisterEventHandlers(BloombergSessionWrapper wrapper)
        {
            var events = new List<Event.EventType> { Event.EventType.PARTIAL_RESPONSE, Event.EventType.RESPONSE };
            wrapper.RegisterEventHandler<ReferenceDataEventHandler>(events);
        }

        private Request CreateRequest(ReferenceDataRequestInfo desc)
        {
            Service service = SessionWrapper.GetService();
            Request request = service.CreateRequest("ReferenceDataRequest");
            FillRequest(request, desc);
            return request;
        }

        private ReferenceDataRequestInfo RegisterNewAsyncRequest(out Request request,
                                                                 Action<ReferenceDataResponse> callback)
        {
            ReferenceDataRequestInfo info = RegisterNewRequest(out request);
            info.Callback = callback;
            return info;
        }

        private ReferenceDataRequestInfo RegisterNewRequest(out Request request)
        {
            var info = new ReferenceDataRequestInfo(Securities, Fields);
            request = CreateRequest(info);
            return info;
        }
    }
}