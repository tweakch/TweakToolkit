using System;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel.Receiver
{
    public class ObjectReceiver : IReceiver<object>
    {
        public IChannel<object> Channel { get; private set; }

        public void SetChannel(string channelName)
        {
            if (Channel != null) Channel.Parsed -= ChannelParsed;
            Channel = ObjectChannel.GetChannel(channelName);
            Channel.Parsed += ChannelParsed;
        }

        private void ChannelParsed(object sender, ParsedEventArgs<object> e)
        {
            LastMessage = e.Message;
            OnReceived(new MessageReceivedEventArgs<object>(Channel, LastMessage));
        }

        public object LastMessage { get; private set; }

        public event EventHandler<MessageReceivedEventArgs<object>> Received;

        protected virtual void OnReceived(MessageReceivedEventArgs<object> e)
        {
            EventHandler<MessageReceivedEventArgs<object>> handler = Received;
            if (handler != null) handler(this, e);
        }
    }
}