using TweakToolkit.Messaging.Channel.Receiver;
using TweakToolkit.Messaging.Channel.Transmitter;

namespace TweakToolkit.Messaging.Channel
{
    public class StringChannel : AChannel<string, StringChannel, StringTransmitterImpl, StringReceiverImpl>
    {
        #region IChannel Members

        public override void Parse(string message)
        {
            OnParsing(new ParsingEventArgs<string>(message));
            AddMessage(message);
            OnParsed(new ParsedEventArgs<string>(message));
        }

        #endregion IChannel Members
    }
}