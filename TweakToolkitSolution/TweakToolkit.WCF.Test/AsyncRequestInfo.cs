using System;

namespace TweakToolkit.WCF.Test
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