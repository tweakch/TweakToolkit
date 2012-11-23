using System;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel
{
    public interface IChannel<T>
    {
        string ChannelName { get; set; }

        void Parse(T message);

        event EventHandler<ParsedEventArgs<T>> Parsed;

        event EventHandler<ParsingEventArgs<T>> Parsing;
    }
}