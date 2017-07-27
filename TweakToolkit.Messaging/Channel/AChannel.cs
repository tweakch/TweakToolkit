using System;
using System.Collections.Generic;
using System.Linq;
using TweakToolkit.Messaging.Channel.Receiver;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel
{
    public abstract class AChannel<TType, TChannel, TTransmitter, TReceiver> : IChannel<TType>
        where TChannel : IChannel<TType>, new()
        where TTransmitter : ITransmitter<TType>, new()
        where TReceiver : IReceiver<TType>, new()
    {
        private static List<IChannel<TType>> _channels;

        protected void AddMessage(TType message)
        {
            _messages.Add(message);
        }

        protected static List<IChannel<TType>> Channels
        {
            get { return _channels ?? (_channels = new List<IChannel<TType>>()); }
            set { _channels = value; }
        }

        public static ITransmitter<TType> CreateTransmitter(string channel)
        {
            //return (ITransmitter<TType>) Activator.CreateInstance(typeof (TTransmitter), channel);
            var transmitter = new TTransmitter();
            transmitter.SetChannel(channel);
            return transmitter;
        }

        public static IReceiver<TType> CreateReceiver(string channel)
        {
            var receiver = new TReceiver();
            receiver.SetChannel(channel);
            return receiver;
        }

        public static IChannel<TType> GetChannel(string name)
        {
            if (!Channels.Any(c => c.ChannelName.Equals(name)))
            {
                Channels.Add(new TChannel { ChannelName = name });
            }
            return Channels.FirstOrDefault(c => c.ChannelName.Equals(name));
        }

        private readonly List<TType> _messages;

        protected AChannel()
        {
            _messages = new List<TType>();
        }

        public string ChannelName { get; set; }

        public abstract void Parse(TType message);

        public event EventHandler<ParsedEventArgs<TType>> Parsed;

        protected virtual void OnParsed(ParsedEventArgs<TType> e)
        {
            EventHandler<ParsedEventArgs<TType>> handler = Parsed;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<ParsingEventArgs<TType>> Parsing;

        protected virtual void OnParsing(ParsingEventArgs<TType> e)
        {
            EventHandler<ParsingEventArgs<TType>> handler = Parsing;
            if (handler != null) handler(this, e);
        }
    }
}