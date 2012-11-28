using System;
using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Exceptions;
using System.Web;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionSession : SessionBase
    {
        public event EventHandler<SubscriptionChangedEventArgs> SubscriptionChanged;

        public SubscriptionSession(SubscriptionBehaviour behaviour)
            : base(behaviour)
        {
            Subscriptions = new Dictionary<CorrelationID, Subscription>();
            SubscriptionFields = new Dictionary<CorrelationID, List<string>>();
            behaviour.SubscriptionDataReceived += new EventHandler<SubscriptionDataEventArgs>(behaviour_SubscriptionDataReceived);
            behaviour.SubscriptionStatusReceived += new EventHandler<SubscriptionStatusEventArgs>(behaviour_SubscriptionStatusReceived);    
        }

        void OnSubscriptionChanged(SubscriptionChangedEventArgs args)
        {
            if (SubscriptionChanged != null)
            {
                SubscriptionChanged(this, args);
            }
        }

        void behaviour_SubscriptionStatusReceived(object sender, SubscriptionStatusEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        void behaviour_SubscriptionDataReceived(object sender, SubscriptionDataEventArgs e)
        {
            var subscription = Subscriptions[e.Id];
            var fieldData = new Dictionary<string, object>();

            foreach (var fieldName in SubscriptionFields[e.Id])
            {
                if(e.Fields.ContainsKey(fieldName)) 
                    fieldData.Add(fieldName, e.Fields[fieldName]);
            }
            OnSubscriptionChanged(new SubscriptionChangedEventArgs(e.Id, e.Topic, fieldData));
        }

        public Dictionary<CorrelationID,Subscription> Subscriptions { get; private set; }

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
                var uri = subscription.SubscriptionString;
                var fieldsParam = HttpUtility.ParseQueryString(uri.Split('?')[1]).Get("fields");              
                var fields = fieldsParam.Split(',').ToList();

                Subscriptions.Add(subscription.CorrelationID, subscription);
                SubscriptionFields.Add(subscription.CorrelationID, fields);
            }
            Session.Subscribe(subscriptionList);
        }

        public void Unsubscribe(IList<Subscription> subscriptionList)
        {
            Session.Unsubscribe(subscriptionList);
        }

        private bool IsKnownCorrelationId(CorrelationID correlationId)
        {
            return Subscriptions.ContainsKey(correlationId);
        }

        public Dictionary<CorrelationID, List<string>> SubscriptionFields { get; set; }
    }
}