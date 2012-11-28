﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Exceptions;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionSession : SessionBase
    {
        public SubscriptionSession()
            : base(new SubscriptionBehaviourBase())
        {
            KnownCorrelationIds = new HashSet<CorrelationID>();
        }
        
        public HashSet<CorrelationID> KnownCorrelationIds { get; private set; }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            return Session.GetSubscriptions();
        }

        public Session.SubscriptionStatus GetSubscriptionStatus(CorrelationID correlationId)
        {
            if (!IsKnownCorrelationId(correlationId)) 
                throw new UnknownCorrelationIdException(correlationId);
            return Session.GetSubscriptionStatus(correlationId);
        }

        public string GetSubscriptionString(CorrelationID correlationId)
        {
            if (!IsKnownCorrelationId(correlationId))
            {
                throw new UnknownCorrelationIdException(correlationId);
            }
            return Session.GetSubscriptionString(correlationId);
        }

        public void Resubscribe(IList<Subscription> subscriptionList)
        {
            foreach (var subscription in subscriptionList.Where(subscription => !IsKnownCorrelationId(subscription.CorrelationID)))
            {
                throw new UnknownCorrelationIdException(subscription.CorrelationID);
            }
            Session.Resubscribe(subscriptionList);
        }
        
        public void Subscribe(IList<Subscription> subscriptionList)
        {
            foreach (var subscription in subscriptionList)
            {
                KnownCorrelationIds.Add(subscription.CorrelationID);
            }
            Session.Subscribe(subscriptionList);
        }

        public void Unsubscribe(IList<Subscription> subscriptionList)
        {
            Session.Unsubscribe(subscriptionList);
        }

        private bool IsKnownCorrelationId(CorrelationID correlationId)
        {
            return KnownCorrelationIds.Contains(correlationId);
        }
    }
}