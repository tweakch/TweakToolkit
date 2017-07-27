using System;

namespace TweakToolkit.EntityFramework.Strategies
{
    public class ExecutedEventArgs : EventArgs
    {
        public ExecutedEventArgs(object message, object result)
        {
            Result = result;
            Message = message;
        }

        public object Message { get; private set; }

        public object Result { get; private set; }
    }
}