using System;
using TweakToolkit.Messaging.Channel.Receiver;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel
{
    public class ObjectChannel : AChannel<object, ObjectChannel, ObjectTransmitter, ObjectReceiver>
    {
        public override void Parse(object message)
        {
            OnParsing(new ParsingEventArgs<object>(message));
            if (message == null) throw new InvalidOperationException();
            AddMessage(message);
            OnParsed(new ParsedEventArgs<object>(message));
        }
    }
}