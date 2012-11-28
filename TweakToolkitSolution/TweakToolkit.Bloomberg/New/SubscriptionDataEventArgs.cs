using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionDataEventArgs : EventArgs
    {
        public SubscriptionDataEventArgs(Message msg)
        {
            Id = msg.CorrelationID;
            Topic = (string)Id.Object;
            Fields = new Dictionary<Name, object>();
            foreach (var field in msg.Elements)
            {
                Fields.Add(field.Name, field.GetValue());
            }
        }

        protected Dictionary<Name, object> Fields { get; private set; }

        protected CorrelationID Id { get; private set; }

        protected string Topic { get; private set; }
    }
}