using System;
using TweakToolkit.WCF.Test.Wrapper;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class AsyncRequestInfo : RequestInfo
    {
        public AsyncRequestInfo(string command, Action<WebserviceResult> callback)
            : base(command)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            Callback = callback;
        }

        public Action<WebserviceResult> Callback { get; set; }
    }
}