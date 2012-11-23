using System.Threading.Tasks;

namespace TweakToolkit.Messaging.Transceiver.Transmitter
{
    public class AsyncMessageTransmitterImpl : MessageTransmitterImpl
    {
        public override void Transmit<T>(T item)
        {
            Task.Factory.StartNew(state => TransmissionLogic((T)state), item);
        }

        private void TransmissionLogic<T>(T item)
        {
            base.Transmit(item);
        }
    }
}