using System;
using TweakToolkit.Messaging.Transceiver.Receiver;
using TweakToolkit.Messaging.Transceiver.Transmitter;

namespace TweakToolkit.Messaging.Transceiver
{
    public abstract class MessageTransceiverBase : IMessageReceiver, IMessageTransmitter
    {
        private TransceiverMode _mode;

        protected MessageTransceiverBase()
        {
            Mode = TransceiverMode.Async;
        }

        public TransceiverMode Mode
        {
            get { return _mode; }
            set
            {
                if (_mode == value) return;
                _mode = value;

                if (Mode == TransceiverMode.Async)
                {
                    MessageTransmitter = new AsyncMessageTransmitterImpl();
                    MessageReceiver = new AsyncMessageReceiverImpl();
                }
                else
                {
                    MessageTransmitter = new MessageTransmitterImpl();
                    MessageReceiver = new MessageReceiverImpl();
                }
            }
        }

        protected MessageTransmitterImpl MessageTransmitter { get; set; }

        protected MessageReceiverImpl MessageReceiver { get; set; }

        public bool DoReceive
        {
            get { return MessageReceiver.DoReceive; }
            set { MessageReceiver.DoReceive = value; }
        }

        public virtual void Receive<TMessage>(Action<TMessage> handler) where TMessage : ITweakMessage
        {
            MessageReceiver.Receive(handler);
        }

        public Guid TransmitterId
        {
            get { return MessageTransmitter.TransmitterId; }
        }

        public bool DoTransmit
        {
            get { return MessageTransmitter.DoTransmit; }
            set { MessageTransmitter.DoTransmit = value; }
        }

        public virtual void Transmit<T>(T item)
        {
            MessageTransmitter.Transmit(item);
        }
    }
}