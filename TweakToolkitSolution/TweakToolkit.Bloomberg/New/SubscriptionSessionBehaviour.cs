using System;
using System.Linq;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class SecuritySubscriptionBehaviour : SubscriptionBehaviourBase
    {
        public override void HandleSubscriptionDataEvent(Event eventObj, Session session)
        {
            if (EventContainsKnownSecurity(eventObj))
            {

            }
            else
            {
                base.HandleSubscriptionDataEvent(eventObj, session);
            } 
        }

        private bool EventContainsKnownSecurity(Event eventObj)
        {

            throw new NotImplementedException();
        }
    }

    public class SubscriptionBehaviourBase : AEventBehaviour
    {
        private static int StartTokenValue = 99;
        private static readonly Name CATEGORY = new Name("category");
        private static readonly Name DESCRIPTION = new Name("description");
        private static readonly Name EXCEPTIONS = new Name("exceptions");
        private static readonly Name FIELD_ID = new Name("fieldId");
        private static readonly Name REASON = new Name("reason");
        private static readonly Name SERVICE_OPENED = new Name("ServiceOpened");
        private static readonly Name SESSION_STARTED = new Name("SessionStarted");
        private CorrelationID startToken = new CorrelationID(StartTokenValue);

        public SubscriptionBehaviourBase()
        {
            Add(Event.EventType.SESSION_STATUS, HandleSessionStatusEvent);
            Add(Event.EventType.SERVICE_STATUS, HandleServiceStatusEvent);
            Add(Event.EventType.SUBSCRIPTION_DATA, HandleSubscriptionDataEvent);
            Add(Event.EventType.SUBSCRIPTION_STATUS, HandleSubscriptionStatusEvent);
        }

        public virtual void HandleSubscriptionDataEvent(Event eventObj, Session session)
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

        public virtual void HandleSubscriptionStatusEvent(Event eventObj, Session session)
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

        string serviceUri = "//blp/mktdata";

        private void HandleSessionStatusEvent(Event eventObject, Session session)
        {
            if (!IsSessionStartedEvent(eventObject)) return;
            try
            {
                startToken = new CorrelationID(StartTokenValue);
                session.OpenServiceAsync(serviceUri,startToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static bool IsSessionStartedEvent(Event arg)
        {
            return arg.Any(message => message.MessageType.Equals(SESSION_STARTED));
        }

        private void HandleServiceStatusEvent(Event eventobject, Session session)
        {
            if (IsServiceOpenedEvent(eventobject))
            {
                Service service = session.GetService(serviceUri);
                OnServiceOpened(new ServiceOpenedEventArgs(service));
            }
        }

        private bool IsServiceOpenedEvent(Event arg)
        {
            return arg.Any(msg =>
                msg.CorrelationID.Equals(startToken) &&
                msg.MessageType.Equals(SERVICE_OPENED));
        }

        public override event EventHandler<ServiceOpenedEventArgs> ServiceOpened;

        protected virtual void OnServiceOpened(ServiceOpenedEventArgs e)
        {
            var handler = ServiceOpened;
            if (handler != null) handler(this, e);
        }
    }
}