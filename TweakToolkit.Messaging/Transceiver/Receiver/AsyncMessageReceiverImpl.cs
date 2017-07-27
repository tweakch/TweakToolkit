using System;
using System.Threading.Tasks;

namespace TweakToolkit.Messaging.Transceiver.Receiver
{
    public class AsyncMessageReceiverImpl : MessageReceiverImpl
    {
        public override void Receive<TMessage>(Action<TMessage> handler)
        {
            Task.Factory.StartNew(state => ReceptionLogic((Action<TMessage>)state), handler);
        }

        private void ReceptionLogic<TMessage>(Action<TMessage> handler) where TMessage : ITweakMessage
        {
            base.Receive(handler);
        }
    }
}