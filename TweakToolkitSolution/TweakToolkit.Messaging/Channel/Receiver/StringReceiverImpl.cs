using System;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel.Receiver
{
    public class StringReceiverImpl : IReceiver<string>
    {
        #region IStringReceiver Members

        public event EventHandler<MessageReceivedEventArgs<string>> Received;

        public IChannel<string> Channel { get; private set; }

        public string LastMessage { get; private set; }

        public void SetChannel(string channelName)
        {
            if (Channel != null) Channel.Parsed -= ChannelOnParsed;
            Channel = StringChannel.GetChannel(channelName);
            Channel.Parsed += ChannelOnParsed;
        }

        #endregion IStringReceiver Members

        public void OnReceived(MessageReceivedEventArgs<string> e)
        {
            EventHandler<MessageReceivedEventArgs<string>> handler = Received;
            if (handler != null) handler(this, e);
        }

        private void ChannelOnParsed(object sender, ParsedEventArgs<string> parsedEventArgs)
        {
            LastMessage = parsedEventArgs.Message;
            OnReceived(new MessageReceivedEventArgs<string>(Channel, LastMessage));
        }
    }
}