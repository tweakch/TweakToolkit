﻿using System;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class WebserviceResult
    {
        public WebserviceResult(RequestInfo userState, object[] result)
        {
            ServiceResult = result;
            ParseResult();
            RequestInfo = userState;
        }

        public WebserviceResult(RequestInfo userState, object[] result, Exception exception)
        {
            ServiceResult = result;
            ParseResult();
            if (ServiceException == null) ServiceException = exception;
            RequestInfo = userState;
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
            throw new NotImplementedException();
        }

        private void ParseResult()
        {
            Completed = (bool)ServiceResult[0];
            if (!Completed) ServiceException = new OperationCanceledException(GetMessage());
            ServiceMessage = GetMessage();
        }
    }
}