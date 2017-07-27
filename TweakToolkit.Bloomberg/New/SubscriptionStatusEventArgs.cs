using System;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionStatusEventArgs : EventArgs
    {
        public SubscriptionStatusEventArgs(Message msg)
        {
            Id = msg.CorrelationID;

            Topic = msg.TopicName;

            if (msg.HasElement(Settings.Default.Bloomberg_Name_Reason))
            {
                Reason = new SubscriptionStatusReason(msg.GetElement(Settings.Default.Bloomberg_Name_Reason));
            }

            if (msg.HasElement(Settings.Default.Bloomberg_Name_Exceptions))
            {
                Exceptions = new SubscriptionStatusExceptions(msg.GetElement(Settings.Default.Bloomberg_Name_Exceptions));
            }
        }

        protected SubscriptionStatusExceptions Exceptions { get; set; }

        protected CorrelationID Id { get; set; }

        protected SubscriptionStatusReason Reason { get; set; }

        protected string Topic { get; set; }
    }
}