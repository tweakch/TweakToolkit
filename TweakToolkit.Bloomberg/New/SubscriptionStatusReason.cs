using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Properties;

namespace TweakToolkit.Bloomberg.New
{
    public static class ElementExtensions
    {
        public static string GetValueOrDefault(this Element element, string name)
        {
            if ((element.HasElement(name)) && (element.GetElement(name).GetValue()!=null))
            {
                return element.GetElementAsString(name);
            }
            return string.Empty;
        }
    }

    public class SubscriptionStatusReason 
    {
        public SubscriptionStatusReason(Element reason)
        {
            Source = reason.GetValueOrDefault(Settings.Default.Bloomberg_Name_Source);
            ErrorCode = reason.GetValueOrDefault(Settings.Default.Bloomberg_Name_ErrorCode);
            SubCategory = reason.GetValueOrDefault(Settings.Default.Bloomberg_Name_Subcategory);
            Category = reason.GetValueOrDefault(Settings.Default.Bloomberg_Name_Category);
            Description = reason.GetValueOrDefault(Settings.Default.Bloomberg_Name_Exceptions);
        }
        
        protected string Category { get; set; }

        protected string Description { get; set; }

        public string Source { get; set; }

        public string ErrorCode { get; set; }

        public string SubCategory { get; set; }
    }
}