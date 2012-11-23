namespace TweakToolkit.Messaging.Channel.Transmitter
{
    public class StringTransmitterImpl : ITransmitter<string>
    {
        #region IStringTransmitter Members

        public void Send(string message)
        {
            Channel.Parse(message);
        }

        public void SetChannel(string channelName)
        {
            Channel = StringChannel.GetChannel(channelName);
        }

        public IChannel<string> Channel { get; private set; }

        #endregion IStringTransmitter Members
    }
}