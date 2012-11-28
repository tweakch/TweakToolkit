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
            Topic = msg.TopicName;
            Fields = new Dictionary<string, object>();
            foreach (var field in msg.Elements)
            {
                var typeDesc = field.TypeDefinition;
                if (field.IsNull)
                {
                    Fields.Add(field.Name.ToString(), null);
                }
                else
                {
                    Fields.Add(field.Name.ToString(), field.GetValue());
                }
            }
        }

        public Dictionary<string, object> Fields { get; private set; }

        public CorrelationID Id { get; private set; }

        public string Topic { get; private set; }
    }
}