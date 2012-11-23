using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    public class ReferenceDataEventHandler : AEventHandlerBase
    {
        public IParseSessionMessages Parser { get; set; }

        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            foreach (Message msg in eventObj)
            {
                ReferenceDataRequestInfo requestDescription = session.RequestDescriptions[msg.CorrelationID];
                requestDescription.Response.SaveMessage(msg);

                if (requestDescription.Callback != null && eventObj.Type == Event.EventType.RESPONSE)
                {
                    requestDescription.Callback(requestDescription.Response);
                }
            }
        }
    }
}