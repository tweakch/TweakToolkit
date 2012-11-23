using System;

namespace TweakToolkit.WCF.Test
{
    public interface ICatWebserviceWrapper
    {
        WebserviceState WebserviceState { get; }

        WebserviceResult Connect();

        void ConnectAsync(Action<WebserviceResult> callback);

        WebserviceResult Disconnect();

        void DisconnectAsync(Action<WebserviceResult> callback);
    }
}