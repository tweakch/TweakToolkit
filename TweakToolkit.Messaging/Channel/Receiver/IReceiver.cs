using System;

namespace TweakToolkit.Messaging.Channel.Receiver
{
    public interface IReceiver<T>
    {
        IChannel<T> Channel { get; }

        T LastMessage { get; }

        void SetChannel(string channelName);

        event EventHandler<MessageReceivedEventArgs<T>> Received;
    }
}