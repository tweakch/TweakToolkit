using System;

namespace TweakToolkit.Messaging.Channel.Receiver
{
    public class MessageReceivedEventArgs<T> : EventArgs
    {
        public MessageReceivedEventArgs(IChannel<T> channel, T message)
        {
            Channel = channel;
            Message = message;
        }

        public IChannel<T> Channel { get; private set; }

        public T Message { get; private set; }
    }
}