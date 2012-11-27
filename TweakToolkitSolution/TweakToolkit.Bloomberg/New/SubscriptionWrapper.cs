using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionWrapper
    {
        private readonly SubscriptionSession _sessionBase;

        public SubscriptionWrapper()
        {
            _sessionBase = new SubscriptionSession();
        }

        public CorrelationID GenerateToken()
        {
            return _sessionBase.GenerateToken();
        }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            return _sessionBase.GetSubscriptions();
        }

        public Session.SubscriptionStatus GetSubscriptionStatus(CorrelationID correlationId)
        {
            return _sessionBase.GetSubscriptionStatus(correlationId);
        }

        public string GetSubscriptionString(CorrelationID correlationId)
        {
            return _sessionBase.GetSubscriptionString(correlationId);
        }

        public void Resubscribe(IList<Subscription> subscriptionList)
        {
            _sessionBase.Resubscribe(subscriptionList);
        }

        public bool Start()
        {
            try
            {
                _sessionBase.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Stop()
        {
            _sessionBase.Stop();
        }

        public void Subscribe(IList<Subscription> subscriptionList)
        {
            _sessionBase.Subscribe(subscriptionList);
        }

        public void Unsubscribe(IList<Subscription> subscriptionList)
        {
            _sessionBase.Unsubscribe(subscriptionList);
        }
    }
}