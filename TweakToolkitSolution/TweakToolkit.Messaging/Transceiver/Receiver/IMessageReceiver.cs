using System;

namespace TweakToolkit.Messaging.Transceiver.Receiver
{
    public interface IMessageReceiver
    {
        bool DoReceive { get; set; }

        void Receive<TMessage>(Action<TMessage> handler) where TMessage : ITweakMessage;
    }
}