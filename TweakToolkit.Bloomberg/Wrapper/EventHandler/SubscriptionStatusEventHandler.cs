using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    internal class SubscriptionStatusEventHandler : AEventHandlerBase
    {
        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            Console.WriteLine("Processing SUBSCRIPTION_STATUS");
            foreach (Message msg in eventObj)
            {
                var topic = (string)msg.CorrelationID.Object;
                Console.WriteLine(DateTime.Now.ToString("s") +
                                  ": " + topic + " - " + msg.MessageType);

                if (msg.HasElement(ReasonElementId))
                {
                    // This can occur on SubscriptionFailure.
                    Element reason = msg.GetElement(ReasonElementId);
                    Console.WriteLine("\t" +
                                      reason.GetElement(CategoryElementId).GetValueAsString() +
                                      ": " + reason.GetElement(DescriptionElementId).GetValueAsString());
                }

                if (msg.HasElement(ExceptionElementId))
                {
                    // This can occur on SubscriptionStarted if at least
                    // one field is good while the rest are bad.
                    Element exceptions = msg.GetElement(ExceptionElementId);
                    for (int i = 0; i < exceptions.NumValues; ++i)
                    {
                        Element exInfo = exceptions.GetValueAsElement(i);
                        Element fieldId = exInfo.GetElement(FieldIdElementId);
                        Element reason = exInfo.GetElement(ReasonElementId);
                        Console.WriteLine("\t" + fieldId.GetValueAsString() +
                                          ": " + reason.GetElement(CategoryElementId).GetValueAsString());
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}