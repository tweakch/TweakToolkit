using TweakToolkit.EntityFramework.WebsiteData;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public class BarrierWebsiteDescription
    {
        public BarrierWebsiteDescription(BarrierWebsiteData data)
        {
            Valor = data.Valor;
            Name = data.Name;
            NameEn = data.NameEN;
            Barrier = data.Value;
            Observation = data.Observation;
            ObservationEn = data.ObservationEn;
            Settlement = data.SettlementEn;
            SettlementEn = data.SettlementEn;
            Trigger = data.Trigger;
            TriggerEn = data.TriggerEn;
        }

        public decimal Barrier { get; set; }

        public string Name { get; set; }

        public string NameEn { get; set; }

        public string Observation { get; set; }

        public string ObservationEn { get; set; }

        public string Settlement { get; set; }

        public string SettlementEn { get; set; }

        public string Trigger { get; set; }

        public string TriggerEn { get; set; }

        public int Valor { get; set; }
    }
}