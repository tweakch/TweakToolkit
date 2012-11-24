using System;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class WebserviceResult
    {
        public WebserviceResult(RequestInfo userState, object[] result)
        {
            RequestInfo = userState;
            ServiceResult = result;
            ParseResult();
        }

        //TODO: Inspect the service behaviour... Is there ever an exception on the service that requires this constructor?
        public WebserviceResult(RequestInfo userState, object[] result, Exception exception)
        {
            RequestInfo = userState;
            ServiceResult = result;
            ParseResult();
            if (ServiceException == null) ServiceException = exception;
        }

        public WebserviceResult(RequestInfo userState, bool result, Exception exception)
            : this(userState, new object[] { result }, exception)
        {
        }

        public WebserviceResult(RequestInfo userState, bool result)
            : this(userState, new object[] { result })
        {
        }

        public bool Completed { get; set; }

        public RequestInfo RequestInfo { get; set; }

        public Exception ServiceException { get; set; }

        public string ServiceMessage { get; private set; }

        public object[] ServiceResult { get; set; }

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
                return string.Format("{0}: {1}",ServiceResult[2], ServiceResult[1]);
            }
            throw new NotImplementedException();
        }

        private void ParseResult()
        {
            Completed = (bool)ServiceResult[0];
            var serviceMessage = GetMessage();
            if (!Completed)
            {
                serviceMessage = string.Format("{0} caused an exception: {1}",
                                               RequestInfo.Opearation,
                                               serviceMessage);
                ServiceException = new OperationCanceledException(serviceMessage);
            }
            ServiceMessage = serviceMessage;
        }
    }
}