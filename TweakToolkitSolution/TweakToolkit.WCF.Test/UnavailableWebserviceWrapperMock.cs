using System;

namespace TweakToolkit.WCF.Test
{
    public class UnavailableWebserviceWrapperMock : ICatWebserviceWrapper
    {
        public WebserviceState WebserviceState { get; private set; }

        public WebserviceResult Connect()
        {
            return new WebserviceResult(false,null,true,new RequestInfo("Connect"));
        }

        public void ConnectAsync(Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult Disconnect()
        {
            return new WebserviceResult(false, null, true, new RequestInfo("Disconnect"));
        }

        public void DisconnectAsync(Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }
    }
}