using System;

namespace TweakToolkit.Messaging.Channel.Transmitter
{
    public class ParsingEventArgs<T> : EventArgs
    {
        public ParsingEventArgs(T message)
        {
            Message = message;
        }

        public T Message { get; private set; }
    }
}