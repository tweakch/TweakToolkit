using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TweakToolkit.Messaging.Transceiver.Receiver;
using TweakToolkit.Messaging.Transceiver.Transmitter;

namespace TweakToolkit.Messaging.Transceiver
{
    public class MessageMessageTransceiver : MessageTransceiverBase, IMessageReceiver, IMessageTransmitter
    {
        public MessageMessageTransceiver()
        {
            InitializeComponent();
            ReceivedMessages.CollectionChanged += QueueMessage;
            TransmittedMessages.CollectionChanged += QueueMessage;
        }

        protected ObservableCollection<object> MessageQueue { get; set; }

        public ObservableCollection<ITweakMessage> ReceivedMessages { get; private set; }

        public ObservableCollection<ITweakMessage> TransmittedMessages { get; private set; }

        public override void Receive<TMessage>(Action<TMessage> handler)
        {
            base.Receive(handler);
            AddMessage("Listening for " + handler);
        }

        public override void Transmit<T>(T item)
        {
            base.Transmit(item);
            AddMessage("Transmitting " + item);
        }

        private void InitializeComponent()
        {
            MessageQueue = new ObservableCollection<object>();
            ReceivedMessages = new ObservableCollection<ITweakMessage>();
            TransmittedMessages = new ObservableCollection<ITweakMessage>();
        }

        protected void AddMessage(object message)
        {
            MessageQueue.Add(message);
        }

        private void QueueMessage(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (object newItem in e.NewItems)
            {
                AddMessage(newItem);
                MessageQueue.Add(newItem);
            }
        }

        public void TransmitMessage<TMessage>(TMessage message) where TMessage : ITweakMessage
        {
            message.TransmitterId = TransmitterId;
            base.Transmit(message);
            AddMessage(message);
        }
    }
}