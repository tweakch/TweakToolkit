using System;

namespace TweakToolkit.EntityFramework.Strategies
{
    public class StrategyErrorEventArgs : GatewayErrorEventArgs
    {
        public StrategyErrorEventArgs(Exception ex)
            : base(ex)
        {
        }
    }
}