using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionChangedEventArgs : EventArgs
    {
        public SubscriptionChangedEventArgs(Bloomberglp.Blpapi.CorrelationID correlationID, string topic, Dictionary<string, object> fieldData)
        {
            Id = correlationID;
            Topic = topic;
            FieldData = fieldData;
        }

        public Bloomberglp.Blpapi.CorrelationID Id { get; set; }

        public string Topic { get; set; }

        public Dictionary<string, object> FieldData { get; set; }
    }
}
