using System;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class WebserviceResult : IWebserviceResult
    {
        public static IWebserviceResult Create(string requestInfo, object[] result)
        {
            return new WebserviceResult(new RequestInfo(requestInfo), result);
        }

        public static IWebserviceResult Create(string requestInfo, bool result)
        {
            return Create(requestInfo, new object[] { result });
        }

        public WebserviceResult(RequestInfo userState, object[] result)
        {
            RequestInfo = userState;
            ServiceResult = result;
            ParseResult();
        }

        public WebserviceResult(RequestInfo userState, bool result)
            : this(userState, new object[] { result })
        {
        }

        public virtual bool HasErrors
        {
            get { return !(bool)ServiceResult[0]; }
        }

        public RequestInfo RequestInfo { get; set; }

        public virtual string ServiceMessage { get; private set; }

        protected object[] ServiceResult { get; set; }

        private string GetMessage()
        {
            if (ServiceResult.Length == 1)
            {
                return string.Empty;
            }
            if (ServiceResult.Length == 2)
            {
                return (string)ServiceResult[1];
            }
            if (ServiceResult.Length == 3)
            {
                return string.Format("{0}: {1}", ServiceResult[2], ServiceResult[1]);
            }
            throw new NotImplementedException();
        }

        private void ParseResult()
        {
            var serviceMessage = GetMessage();
            if (HasErrors)
            {
                serviceMessage = string.Format("{0} caused an exception: {1}",
                                               RequestInfo.Opearation,
                                               serviceMessage);
            }
            ServiceMessage = serviceMessage;
        }
    }
}