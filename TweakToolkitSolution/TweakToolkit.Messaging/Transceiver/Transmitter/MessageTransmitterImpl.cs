using System;
using MyToolkit.Messaging;

namespace TweakToolkit.Messaging.Transceiver.Transmitter
{
    public class MessageTransmitterImpl : IMessageTransmitter
    {
        public MessageTransmitterImpl()
        {
            TransmitterId = Guid.NewGuid();
            DoTransmit = true;
        }

        public Guid TransmitterId { get; private set; }

        public bool DoTransmit { get; set; }

        public virtual void Transmit<T>(T item)
        {
            if (!DoTransmit) return;
            item.Send();
        }
    }
}