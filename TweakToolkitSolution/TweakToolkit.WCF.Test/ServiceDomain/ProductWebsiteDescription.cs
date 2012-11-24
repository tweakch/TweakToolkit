using System;
using System.Globalization;
using TweakToolkit.WCF.Test.Data;

namespace TweakToolkit.WCF.Test.ServiceDomain
{
    public struct ProductWebsiteDescription
    {
        public ProductWebsiteDescription(ProductWebsiteData data, bool hasEnglish = false)
            : this()
        {
            AssetClass = AssignString(data.AssetClass);
            AssetClassEn = AssignString(data.AssetClassEn);
            bonuslevel = AssignString(data.BonusLevel);
            bonuslevelEn = AssignString(data.BonusLevelEN);
            CallData = AssignString(data.CallData);
            CallDataEn = AssignString(data.CallDataEn);
            Cap = AssignString(data.Cap);
            capEn = AssignString(data.CapEN);
            ConditionalObservation = AssignString(data.CouponConditional);
            couponBedingtEn = AssignString(data.CouponConditionalEN);
            CouponGuaranteed_En = AssignString(data.CouponGuaranteedEN);
            CouponObservation = AssignString(data.CouponGuaranteed);

            cpbedingt = AssignString(data.ConditionalObservation);
            cpbedingtEn = AssignString(data.ConditionalObservationEn);
            CPFloater = AssignString(data.FloaterObservation);
            CPFloaterEn = AssignString(data.FloaterObservationEn);
            CpGuaranteed = AssignString(data.CouponObservation);
            CpGuaranteedEn = AssignString(data.CouponObservationEn);

            Currency = AssignString(data.Currency);
            CurrencyRisk = AssignString(data.CurrencyRisk);
            CurrencyRiskEn = AssignString(data.CurrencyRiskEn);
            Dirty = AssignString(data.IsPriceDirty ? "dirty" : "clean");
            Discount = AssignString(data.Discount);
            DiscountEn = AssignString(data.DiscountEN);
            EarlyRedemption = AssignString(data.EarlyRedemption);
            EarlyRedemptionEn = AssignString(data.EarlyRedemptionEn);

            if (data.Pricing.Equals("Nominal"))
            {
                EmissionPrice = AssignString(data.EmissionPrice + "%");
                NumberFormatInfo numberFormat = CultureInfo.GetCultureInfo("de-CH").NumberFormat;
                Nominal = AssignString(data.Currency + " " + data.Notional.ToString("##,##", numberFormat));
                SmallestTradeableUnit =
                    AssignString(data.Currency + " " + data.SmallestTradeableUnit.ToString("##,##", numberFormat));
            }
            else
            {
                EmissionPrice = AssignString(data.Currency + " " + data.EmissionPrice);
                Nominal = AssignString(data.Notional + " Zertifikat(e)");
                SmallestTradeableUnit = AssignString(data.SmallestTradeableUnit + " Zertifikat(e)");
            }

            EmissionType = AssignString(data.EmissionTypeDescription);
            EndFixationDate = AssignDateTime(data.EndFixationDate.GetValueOrDefault());
            Floater = AssignString(data.Floater);
            FloaterEn = AssignString(data.FloaterEN);
            Guarantor = AssignString(data.Guarantor);
            HasEnglish = hasEnglish;
            ISIN = AssignString(data.ISIN);
            Issuer = AssignString(data.Issuer);
            issuerNameShort = AssignString(data.IssuerShort);
            LeadManager = AssignString(data.LeadManager);
            maxCoupon = AssignString(data.CouponMaximal);
            maxCouponEn = AssignString(data.CouponMaximalEN);
            MaxPayback = AssignString(data.PaybackMaximal);
            MaxPaybackEn = AssignString(data.PaybackMaximaEN);
            MaxYield = AssignString(data.MaxYield);
            MaxYieldEn = AssignString(data.MaxYieldEN);
            minCoupon = AssignString(data.CouponMinimal);
            minCouponEn = AssignString(data.CouponMinimalEN);
            MinPayback = AssignString(data.PaybackMinimal);
            MinPaybackEn = AssignString(data.PaybackMinimalEN);
            Name = AssignString(data.Name);
            NameEn = AssignString(data.NameEN);
            Partizipation = AssignString(data.Participation);
            PartizipationEn = AssignString(data.ParticipationEN);
            PartizipationText = AssignString(data.TextParticipation);
            PartizipationTextEn = AssignString(data.TextParticipationEN);
            Pricing = AssignString(data.Pricing);
            PricingEn = AssignString(data.PricingEn);
            ProductCat = AssignString(data.ProductCategory);
            ProductCatEn = AssignString(data.ProductCategoryEn);
            productKatId = AssignInteger(data.ProductCategoryValue.GetValueOrDefault());
            ProductState = AssignString(data.ProductState);
            ProductType = AssignString(data.ProductType);
            ProductTypeEn = AssignString(data.ProductTypeEn);
            productTypeId = AssignInteger(data.ProductTypeValue);
            Protection = AssignString(data.Protection);
            ProtectionEn = AssignString(data.ProtectionEN);
            ProtectionType = AssignString(data.ProtectionType);
            RedemptionDate = AssignDateTime(data.RedemptionDate.GetValueOrDefault());
            s1t = AssignString(data.Additional1Text);
            s1tEN = AssignString(data.Additional1TextEN);
            s1v = AssignString(data.Additional1Value);
            s1vEn = AssignString(data.Additional1ValueEN);
            s2t = AssignString(data.Additional2Text);
            s2tEn = AssignString(data.Additional2TextEN);
            s2v = AssignString(data.Additional2Value);
            s2vEn = AssignString(data.Additional2ValueEN);
            s3t = AssignString(data.Additional3Text);
            s3tEn = AssignString(data.Additional3TextEN);
            s3v = AssignString(data.Additional3Value);
            s3vEn = AssignString(data.Additional3ValueEN);
            StartFixationDate = AssignDateTime(data.StartFixationDate.GetValueOrDefault());
            StockExchange = AssignString(data.StockExchange);
            Symbol = AssignString(data.Symbol);
            Text_Bed_Coupon = AssignString(data.TextCouponConditional);
            textBedCoupon_En = AssignString(data.TextCouponConditionalEN);
            TextCoupon = AssignString(data.TextCoupon);
            TextCouponEn = AssignString(data.TextCouponEN);
            TextEarlyRedemtpion = AssignString(data.EarlyRedemption);
            TextEarlyRedemtpionEn = AssignString(data.EarlyRedemptionEn);
            TextFloater = AssignString(data.TextFloater);
            TextFloaterEn = AssignString(data.TextFloaterEN);
            TextMaxPayback = AssignString(data.TextPaybackMaximal);
            TextMaxPaybackEn = AssignString(data.TextPaybackMaximalEN);
            Valor = AssignInteger(data.Valor);
            ValutaDate = AssignDateTime(data.ValutaDate.GetValueOrDefault());
        }

        public string AssetClass { get; private set; }

        public string AssetClassEn { get; private set; }

        public string bonuslevel { get; private set; }

        public string bonuslevelEn { get; private set; }

        public string CallData { get; private set; }

        public string CallDataEn { get; private set; }

        public string Cap { get; private set; }

        public string capEn { get; private set; }

        public string ConditionalObservation { get; private set; }

        public string couponBedingtEn { get; private set; }

        public string CouponGuaranteed_En { get; private set; }

        public string CouponObservation { get; private set; }

        public string cpbedingt { get; private set; }

        public string cpbedingtEn { get; private set; }

        public string CPFloater { get; private set; }

        public string CPFloaterEn { get; private set; }

        public string CpGuaranteed { get; private set; }

        public string CpGuaranteedEn { get; private set; }

        public string Currency { get; private set; }

        public string CurrencyRisk { get; private set; }

        public string CurrencyRiskEn { get; private set; }

        public string Dirty { get; private set; }

        public string Discount { get; private set; }

        public string DiscountEn { get; private set; }

        public string EarlyRedemption { get; private set; }

        public string EarlyRedemptionEn { get; private set; }

        public string EmissionPrice { get; private set; }

        public string EmissionType { get; private set; }

        public DateTime EndFixationDate { get; private set; }

        public string Floater { get; private set; }

        public string FloaterEn { get; private set; }

        public string Guarantor { get; private set; }

        public bool HasEnglish { get; private set; }

        public string ISIN { get; private set; }

        public string Issuer { get; private set; }

        public string issuerNameShort { get; private set; }

        public string LeadManager { get; private set; }

        public string maxCoupon { get; private set; }

        public string maxCouponEn { get; private set; }

        public string MaxPayback { get; private set; }

        public string MaxPaybackEn { get; private set; }

        public string MaxYield { get; private set; }

        public string MaxYieldEn { get; private set; }

        public string minCoupon { get; private set; }

        public string minCouponEn { get; private set; }

        public string MinPayback { get; private set; }

        public string MinPaybackEn { get; private set; }

        public string Name { get; private set; }

        public string NameEn { get; private set; }

        public string Nominal { get; private set; }

        public string Partizipation { get; private set; }

        public string PartizipationEn { get; private set; }

        public string PartizipationText { get; private set; }

        public string PartizipationTextEn { get; private set; }

        public string Pricing { get; private set; }

        public string PricingEn { get; private set; }

        public string ProductCat { get; private set; }

        public string ProductCatEn { get; private set; }

        public int productKatId { get; private set; }

        public string ProductState { get; private set; }

        public string ProductType { get; private set; }

        public string ProductTypeEn { get; private set; }

        public int productTypeId { get; private set; }

        public string Protection { get; private set; }

        public string ProtectionEn { get; private set; }

        public string ProtectionType { get; private set; }

        public DateTime RedemptionDate { get; private set; }

        public string s1t { get; private set; }

        public string s1tEN { get; private set; }

        public string s1v { get; private set; }

        public string s1vEn { get; private set; }

        public string s2t { get; private set; }

        public string s2tEn { get; private set; }

        public string s2v { get; private set; }

        public string s2vEn { get; private set; }

        public string s3t { get; private set; }

        public string s3tEn { get; private set; }

        public string s3v { get; private set; }

        public string s3vEn { get; private set; }

        public string SmallestTradeableUnit { get; private set; }

        public DateTime StartFixationDate { get; private set; }

        public string StockExchange { get; private set; }

        public string Symbol { get; private set; }

        public string Text_Bed_Coupon { get; private set; }

        public string textBedCoupon_En { get; private set; }

        public string TextCoupon { get; private set; }

        public string TextCouponEn { get; private set; }

        public string TextEarlyRedemtpion { get; private set; }

        public string TextEarlyRedemtpionEn { get; private set; }

        public string TextFloater { get; private set; }

        public string TextFloaterEn { get; private set; }

        public string TextMaxPayback { get; private set; }

        public string TextMaxPaybackEn { get; private set; }

        public int Valor { get; private set; }

        public DateTime ValutaDate { get; private set; }

        private static string AssignString(object obj)
        {
            return (string)(obj ?? string.Empty);
        }

        private static int AssignInteger(object obj)
        {
            return (int)(obj ?? 0);
        }
        
        private static DateTime AssignDateTime(object obj)
        {
            return (DateTime) (obj ?? new DateTime(1900,1,1));
        }

    }
}