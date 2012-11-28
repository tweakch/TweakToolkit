using System;
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
}