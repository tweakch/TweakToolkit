using System;

namespace TweakToolkit.EntityFramework.Strategies
{
    public class ExecutingEventArgs : EventArgs
    {
        public ExecutingEventArgs(object message)
        {
            Message = message;
        }

        public object Message { get; private set; }
    }
}