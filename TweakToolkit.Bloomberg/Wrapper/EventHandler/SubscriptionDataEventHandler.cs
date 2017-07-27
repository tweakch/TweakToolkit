using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    internal class SubscriptionDataEventHandler : AEventHandlerBase
    {
        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            foreach (Message msg in eventObj)
            {
                var topic = (string)msg.CorrelationID.Object;

                foreach (Element field in msg.Elements)
                {
                    if (field.IsNull)
                    {
                        continue;
                    }

                    // Assume all values are scalar.
                }
            }
        }
    }
}