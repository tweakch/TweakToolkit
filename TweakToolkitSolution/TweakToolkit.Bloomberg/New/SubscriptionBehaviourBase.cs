using System;
using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionBehaviourBase : AEventBehaviour
    {
        private const string ServiceUri = "//blp/mktdata";
        private const int StartTokenValue = 42;

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

        public override event EventHandler<ServiceOpenedEventArgs> ServiceOpened;

        public virtual event EventHandler<SubscriptionDataEventArgs> SubscriptionDataReceived;

        public virtual event EventHandler<SubscriptionStatusEventArgs> SubscriptionStatusReceived;

        public virtual void HandleSubscriptionDataEvent(Event eventObj, Session session)
        {
            foreach (var msg in eventObj)
            {
                OnSubscriptionDataReceived(new SubscriptionDataEventArgs(msg));
            }
        }

        public virtual void HandleSubscriptionStatusEvent(Event eventObj, Session session)
        {
            foreach (var msg in eventObj)
            {
                OnSubscriptionStatusReceived(new SubscriptionStatusEventArgs(msg));
            }
        }

        protected virtual void OnServiceOpened(ServiceOpenedEventArgs e)
        {
            var handler = ServiceOpened;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSubscriptionDataReceived(SubscriptionDataEventArgs e)
        {
            var handler = SubscriptionDataReceived;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSubscriptionStatusReceived(SubscriptionStatusEventArgs e)
        {
            var handler = SubscriptionStatusReceived;
            if (handler != null) handler(this, e);
        }

        private static bool IsSessionStartedEvent(IEnumerable<Message> arg)
        {
            return arg.Any(message => message.MessageType.Equals(SESSION_STARTED));
        }

        private void HandleServiceStatusEvent(Event eventobject, Session session)
        {
            if (!IsServiceOpenedEvent(eventobject)) return;
            var service = session.GetService(ServiceUri);
            OnServiceOpened(new ServiceOpenedEventArgs(service));
        }

        private void HandleSessionStatusEvent(Event eventObject, Session session)
        {
            if (!IsSessionStartedEvent(eventObject)) return;
            try
            {
                startToken = new CorrelationID(StartTokenValue);
                session.OpenServiceAsync(ServiceUri, startToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool IsServiceOpenedEvent(IEnumerable<Message> arg)
        {
            return arg.Any(msg =>
                           msg.CorrelationID.Equals(startToken) &&
                           msg.MessageType.Equals(SERVICE_OPENED));
        }
    }
}