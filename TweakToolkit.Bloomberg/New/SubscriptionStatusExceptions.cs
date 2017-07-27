using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionStatusExceptions
    {
        public SubscriptionStatusExceptions(Element exceptions)
        {
            FieldId = new List<string>();
            ExceptionReason = new List<SubscriptionStatusReason>();
            for (int i = 0; i < exceptions.NumValues; ++i)
            {
                Element exInfo = exceptions.GetValueAsElement(i);
                FieldId.Add(exInfo.GetElement(Settings.Default.Bloomberg_Name_FieldId).GetValueAsString());
                ExceptionReason.Add(new SubscriptionStatusReason(exInfo.GetElement(Settings.Default.Bloomberg_Name_Reason)));
            }
        }

        protected List<SubscriptionStatusReason> ExceptionReason { get; set; }

        protected List<string> FieldId { get; set; }
    }
}