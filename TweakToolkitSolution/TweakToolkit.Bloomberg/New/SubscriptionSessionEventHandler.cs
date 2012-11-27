using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionSessionEventHandler : ASessionEventHandler
    {
        private static readonly Name CATEGORY = new Name("category");
        private static readonly Name DESCRIPTION = new Name("description");
        private static readonly Name EXCEPTIONS = new Name("exceptions");
        private static readonly Name FIELD_ID = new Name("fieldId");
        private static readonly Name REASON = new Name("reason");

        public static void HandleSubscriptionDataEvent(Event eventObj)
        {
            System.Console.WriteLine("Processing SUBSCRIPTION_DATA");
            foreach (Message msg in eventObj)
            {
                string topic = (string)msg.CorrelationID.Object;
                System.Console.WriteLine(System.DateTime.Now.ToString("s")
                    + ": " + topic + " - " + msg.MessageType);

                foreach (Element field in msg.Elements)
                {
                    if (field.IsNull)
                    {
                        System.Console.WriteLine("\t\t" + field.Name + " is NULL");
                        continue;
                    }

                    // Assume all values are scalar.
                    System.Console.WriteLine("\t\t" + field.Name
                        + " = " + field.GetValueAsString());
                }
            }
        }

        public static void HandleSubscriptionStatusEvent(Event eventObj)
        {
            System.Console.WriteLine("Processing SUBSCRIPTION_STATUS");
            foreach (Message msg in eventObj)
            {
                string topic = (string)msg.CorrelationID.Object;
                System.Console.WriteLine(System.DateTime.Now.ToString("s") +
                    ": " + topic + " - " + msg.MessageType);

                if (msg.HasElement(REASON))
                {
                    // This can occur on SubscriptionFailure.
                    Element reason = msg.GetElement(REASON);
                    System.Console.WriteLine("\t" +
                            reason.GetElement(CATEGORY).GetValueAsString() +
                            ": " + reason.GetElement(DESCRIPTION).GetValueAsString());
                }

                if (msg.HasElement(EXCEPTIONS))
                {
                    // This can occur on SubscriptionStarted if at least
                    // one field is good while the rest are bad.
                    Element exceptions = msg.GetElement(EXCEPTIONS);
                    for (int i = 0; i < exceptions.NumValues; ++i)
                    {
                        Element exInfo = exceptions.GetValueAsElement(i);
                        Element fieldId = exInfo.GetElement(FIELD_ID);
                        Element reason = exInfo.GetElement(REASON);
                        System.Console.WriteLine("\t" + fieldId.GetValueAsString() +
                                ": " + reason.GetElement(CATEGORY).GetValueAsString());
                    }
                }
                System.Console.WriteLine("");
            }
        }

        public override void RegisterSession(SessionBase sessionBase)
        {
            sessionBase.SetEventHandler(HandleSubscriptionDataEvent, Event.EventType.SUBSCRIPTION_DATA);
            sessionBase.SetEventHandler(HandleSubscriptionStatusEvent, Event.EventType.SUBSCRIPTION_STATUS);
        }
    }
}