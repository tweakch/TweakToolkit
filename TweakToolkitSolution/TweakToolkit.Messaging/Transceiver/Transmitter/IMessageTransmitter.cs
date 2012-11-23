using System;

namespace TweakToolkit.Messaging.Transceiver.Transmitter
{
    public interface IMessageTransmitter
    {
        Guid TransmitterId { get; }

        bool DoTransmit { get; set; }

        void Transmit<T>(T item);
    }
}