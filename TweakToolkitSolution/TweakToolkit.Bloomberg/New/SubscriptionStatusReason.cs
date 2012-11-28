using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg.New
{
    public class SubscriptionStatusReason
    {
        public SubscriptionStatusReason(Element reason)
        {
            Category = reason.GetElement(Settings.Default.Bloomberg_Name_Category).GetValueAsString();
            Description = reason.GetElement(Settings.Default.Bloomberg_Name_Exceptions).GetValueAsString();
        }

        protected string Category { get; set; }

        protected string Description { get; set; }
    }
}