using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    internal class SubscriptionAdapter
    {
        private readonly SubscriptionSession _sessionBase;

        public SubscriptionAdapter()
        {
            _sessionBase = new SubscriptionSession();
        }

        public void Cancel(CorrelationID correlationId)
        {
            _sessionBase.Cancel(correlationId);
        }

        public void Cancel(IList<CorrelationID> correlators)
        {
            _sessionBase.Cancel(correlators);
        }

        public Identity CreateIdentity()
        {
            return _sessionBase.CreateIdentity();
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