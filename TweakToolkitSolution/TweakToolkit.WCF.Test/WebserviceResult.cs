using System;
using TweakToolkit.WCF.Test.CatWebservice;

namespace TweakToolkit.WCF.Test
{
    public class WebserviceResult
    {
        private LoginCompletedEventArgs e;

        public WebserviceResult(bool result, Exception exception, bool cancelled, RequestInfo userState)
        {
            Result = result;
            Exception = exception;
            Cancelled = cancelled;
            RequestInfo = userState;
        }

        public bool Result { get; set; }

        public Exception Exception { get; set; }

        public bool Cancelled { get; set; }

        public RequestInfo RequestInfo { get; set; }
    }
}