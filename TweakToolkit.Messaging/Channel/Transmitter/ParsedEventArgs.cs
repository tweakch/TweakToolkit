using System;

namespace TweakToolkit.Messaging.Channel.Transmitter
{
    public class ParsedEventArgs<T> : EventArgs
    {
        public ParsedEventArgs(T message)
        {
            Message = message;
        }

        public T Message { get; private set; }
    }
}