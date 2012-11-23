using System;

namespace TweakToolkit.EntityFramework
{
    public class GatewayErrorEventArgs : EventArgs
    {
        public GatewayErrorEventArgs(Exception ex)
        {
            this.Exception = ex;
        }

        public Exception Exception { get; private set; }
    }
}