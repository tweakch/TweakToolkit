using TweakToolkit.EntityFramework.WebsiteData;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class EventWebsiteDescription
    {
        public EventWebsiteDescription(EventWebsiteData data)
        {
            Valor = data.Valor;
            PeriodEnd = data.PeriodEnd;
            PeriodName = data.PeriodName;
            PeriodNameEn = data.PeriodNameEN;
            PeriodStart = data.PeriodStart;
            ObservationDate = data.ObservationDate;
            Description = data.Description;
            DescriptionEn = data.DescriptionEN;
            EventValutaDate = data.EventValutaDate;
            EventType = data.EventTypeName;
            EventTypeEn = data.EventTypeNameEN;
        }

        public string Description { get; set; }

        public string DescriptionEn { get; set; }

        public string EventType { get; set; }

        public string EventTypeEn { get; set; }

        public System.DateTime EventValutaDate { get; set; }

        public System.DateTime ObservationDate { get; set; }

        public System.DateTime PeriodEnd { get; set; }

        public string PeriodName { get; set; }

        public string PeriodNameEn { get; set; }

        public System.DateTime PeriodStart { get; set; }

        public int Valor { get; set; }
    }
}