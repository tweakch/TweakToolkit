using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyToolkit.Messaging;

namespace TweakToolkit.Messaging.Transceiver.Receiver
{
    public class MessageReceiverImpl : IMessageReceiver
    {
        public MessageReceiverImpl()
        {
            ReceivedMessages = new ObservableCollection<object>();
            DoReceive = true;
        }

        public IList<object> ReceivedMessages { get; set; }

        public bool DoReceive { get; set; }

        public virtual void Receive<TMessage>(Action<TMessage> handler) where TMessage : ITweakMessage
        {
            Messenger.Register<TMessage>(message =>
                                             {
                                                 if (!DoReceive) return;
                                                 ReceivedMessages.Add("Rx: " + message);
                                                 handler(message);
                                             });
        }
    }
}