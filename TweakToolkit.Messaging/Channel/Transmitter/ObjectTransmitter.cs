namespace TweakToolkit.Messaging.Channel.Transmitter
{
    public class ObjectTransmitter : ITransmitter<object>
    {
        public void Send(object message)
        {
            Channel.Parse(message);
        }

        public void SetChannel(string channelName)
        {
            Channel = ObjectChannel.GetChannel(channelName);
        }

        public IChannel<object> Channel { get; private set; }
    }
}