using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.EntityFramework.WebsiteData;
using TweakToolkit.WCF.Test.Properties;

namespace TweakToolkit.WCF.Test
{
    [TestClass]
    public class ServiceDomainTests
    {
        private static readonly DateTime MinimalDate = new DateTime(1900, 1, 1);

        [TestMethod]
        public void BarrierDescriptionTest()
        {
            using (var db = new StruktoWebsiteEntities())
            {
                var barriers = db.GetBarrierWebsiteData(Settings.Default.TestProductValor);
                Assert.IsTrue(barriers.Any());
            }
        }

        [TestMethod]
        public void PriceDescriptionTest()
        {
            using (var db = new StruktoWebsiteEntities())
            {
                var prices = db.GetPriceWebsiteData(Settings.Default.TestProductValor);
                Assert.IsTrue(prices.Any());
            }
        }

        [TestMethod]
        public void ProductDescriptionTest()
        {
            var websiteData = TestHelper.GetProductWebsiteDescription();

            Assert.IsNotNull(websiteData.Valor);
            Assert.IsNotNull(websiteData.Name);
            Assert.IsNotNull(websiteData.Currency);
            Assert.IsNotNull(websiteData.CurrencyRisk);
            Assert.IsNotNull(websiteData.Dirty);
            Assert.IsNotNull(websiteData.Guarantor);
            Assert.IsNotNull(websiteData.LeadManager);
            Assert.IsNotNull(websiteData.Issuer);
            Assert.IsNotNull(websiteData.AssetClass);
            Assert.IsNotNull(websiteData.ProductCat);
            Assert.IsNotNull(websiteData.ProductType);
            Assert.IsNotNull(websiteData.ISIN);
            Assert.IsNotNull(websiteData.StockExchange);
            Assert.IsNotNull(websiteData.Pricing);

            Assert.IsNotNull(websiteData.ValutaDate);
            Assert.IsTrue(websiteData.ValutaDate >= MinimalDate);

            Assert.IsNotNull(websiteData.EmissionPrice);
            Assert.IsNotNull(websiteData.Nominal);

            Assert.IsNotNull(websiteData.RedemptionDate);
            Assert.IsTrue(websiteData.RedemptionDate >= MinimalDate);

            Assert.IsNotNull(websiteData.StartFixationDate);
            Assert.IsTrue(websiteData.StartFixationDate >= MinimalDate);

            Assert.IsNotNull(websiteData.EndFixationDate);
            Assert.IsTrue(websiteData.EndFixationDate >= MinimalDate);

            Assert.IsNotNull(websiteData.CouponObservation);
            Assert.IsNotNull(websiteData.CpGuaranteed);
            Assert.IsNotNull(websiteData.ConditionalObservation);
            Assert.IsNotNull(websiteData.Text_Bed_Coupon);
            Assert.IsNotNull(websiteData.cpbedingt);
            Assert.IsNotNull(websiteData.Floater);
            Assert.IsNotNull(websiteData.CPFloater);
            Assert.IsNotNull(websiteData.TextFloater);
            Assert.IsNotNull(websiteData.minCoupon);
            Assert.IsNotNull(websiteData.maxCoupon);
            Assert.IsNotNull(websiteData.TextCoupon);
            Assert.IsNotNull(websiteData.CallData);
            Assert.IsNotNull(websiteData.EarlyRedemption);
            Assert.IsNotNull(websiteData.TextEarlyRedemtpion);
            Assert.IsNotNull(websiteData.Cap);
            Assert.IsNotNull(websiteData.MaxPayback);
            Assert.IsNotNull(websiteData.TextMaxPayback);
            Assert.IsNotNull(websiteData.Protection);
            Assert.IsNotNull(websiteData.ProtectionType);
            Assert.IsNotNull(websiteData.MinPayback);
            Assert.IsNotNull(websiteData.Partizipation);
            Assert.IsNotNull(websiteData.PartizipationText);
            Assert.IsNotNull(websiteData.Discount);
            Assert.IsNotNull(websiteData.MaxYield);
            Assert.IsNotNull(websiteData.bonuslevel);
            Assert.IsNotNull(websiteData.issuerNameShort);
            Assert.IsNotNull(websiteData.ProductState);
            Assert.IsNotNull(websiteData.productKatId);
            Assert.IsNotNull(websiteData.productTypeId);
            Assert.IsNotNull(websiteData.EmissionType);
            Assert.IsNotNull(websiteData.Symbol);
            Assert.IsNotNull(websiteData.SmallestTradeableUnit);
            Assert.IsNotNull(websiteData.s1t);
            Assert.IsNotNull(websiteData.s1v);
            Assert.IsNotNull(websiteData.s2t);
            Assert.IsNotNull(websiteData.s2v);
            Assert.IsNotNull(websiteData.s3t);
            Assert.IsNotNull(websiteData.s3v);
            Assert.IsNotNull(websiteData.NameEn);
            Assert.IsNotNull(websiteData.CurrencyRiskEn);
            Assert.IsNotNull(websiteData.AssetClassEn);
            Assert.IsNotNull(websiteData.ProductCatEn);
            Assert.IsNotNull(websiteData.ProductTypeEn);
            Assert.IsNotNull(websiteData.PricingEn);
            Assert.IsNotNull(websiteData.CpGuaranteedEn);
            Assert.IsNotNull(websiteData.cpbedingtEn);
            Assert.IsNotNull(websiteData.CPFloaterEn);
            Assert.IsNotNull(websiteData.CallDataEn);
            Assert.IsNotNull(websiteData.EarlyRedemptionEn);
            Assert.IsNotNull(websiteData.CouponGuaranteed_En);
            Assert.IsNotNull(websiteData.couponBedingtEn);
            Assert.IsNotNull(websiteData.textBedCoupon_En);
            Assert.IsNotNull(websiteData.FloaterEn);
            Assert.IsNotNull(websiteData.TextFloaterEn);
            Assert.IsNotNull(websiteData.minCouponEn);
            Assert.IsNotNull(websiteData.maxCouponEn);
            Assert.IsNotNull(websiteData.TextCouponEn);
            Assert.IsNotNull(websiteData.TextEarlyRedemtpionEn);
            Assert.IsNotNull(websiteData.capEn);
            Assert.IsNotNull(websiteData.MaxPaybackEn);
            Assert.IsNotNull(websiteData.TextMaxPaybackEn);
            Assert.IsNotNull(websiteData.ProtectionEn);
            Assert.IsNotNull(websiteData.MinPaybackEn);
            Assert.IsNotNull(websiteData.PartizipationEn);
            Assert.IsNotNull(websiteData.PartizipationTextEn);
            Assert.IsNotNull(websiteData.DiscountEn);
            Assert.IsNotNull(websiteData.MaxYieldEn);
            Assert.IsNotNull(websiteData.bonuslevelEn);
            Assert.IsNotNull(websiteData.s1tEN);
            Assert.IsNotNull(websiteData.s1vEn);
            Assert.IsNotNull(websiteData.s2tEn);
            Assert.IsNotNull(websiteData.s2vEn);
            Assert.IsNotNull(websiteData.s3tEn);
            Assert.IsNotNull(websiteData.s3vEn);
            Assert.IsNotNull(websiteData.HasEnglish);
        }

        
    }
}