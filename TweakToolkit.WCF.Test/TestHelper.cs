using System.Collections.Generic;
using System.Linq;
using TweakToolkit.EntityFramework.WebsiteData;
using TweakToolkit.WCF.Test.Properties;
using TweakToolkit.WCF.Test.ServiceDomain;
using TweakToolkit.WCF.Test.Wrapper;

namespace TweakToolkit.WCF.Test
{
    public class TestHelper
    {
        public static List<BaseValueWebsiteDescription> GetBaseValueWebsiteDescriptions()
        {
            List<BaseValueWebsiteDescription> baseValues;
            using (var db = new StruktoWebsiteEntities())
            {
                baseValues = db.GetBaseValueWebsiteData(Settings.Default.TestProductValor)
                             .Select(data => new BaseValueWebsiteDescription(data)).ToList();
            }
            return baseValues;
        }

        public static List<BarrierWebsiteDescription> GetBarrierWebsiteDescriptions()
        {
            List<BarrierWebsiteDescription> barriers;
            using (var db = new StruktoWebsiteEntities())
            {
                barriers = db.GetBarrierWebsiteData(Settings.Default.TestProductValor)
                             .Select(data => new BarrierWebsiteDescription(data)).ToList();
            }
            return barriers;
        }

        public static ProductWebsiteDescription GetEmptyProductWebsiteDescription()
        {
            var description = new ProductWebsiteDescription(new ProductWebsiteData());
            return description;
        }

        public static List<EventWebsiteDescription> GetEventWebsiteDescriptions()
        {
            List<EventWebsiteDescription> events;
            using (var db = new StruktoWebsiteEntities())
            {
                events = db.GetEventWebsiteData(Settings.Default.TestProductValor)
                             .Select(data => new EventWebsiteDescription(data)).ToList();
            }
            return events;
        }

        public static PriceWebsiteDescription GetPriceWebsiteDescription()
        {
            PriceWebsiteDescription price;
            using (var db = new StruktoWebsiteEntities())
            {
                price = new PriceWebsiteDescription(db.GetPriceWebsiteData(Settings.Default.TestProductValor).Single());
            }
            return price;
        }

        public static ProductWebsiteDescription GetProductWebsiteDescription()
        {
            ProductWebsiteDescription description;
            using (var db = new StruktoWebsiteEntities())
            {
                description =
                    new ProductWebsiteDescription(db.GetProductWebsiteData().Single(p => p.Valor == Settings.Default.TestProductValor));
            }
            return description;
        }
    }
}