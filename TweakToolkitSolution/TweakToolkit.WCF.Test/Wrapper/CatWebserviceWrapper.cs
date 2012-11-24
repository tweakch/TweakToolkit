using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.Properties;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class CatWebserviceWrapper : ICatWebserviceWrapper
    {
        public CatWebserviceWrapper(IImport service)
        {
            Webservice = service;
            WebserviceState = WebserviceWrapperState.Disconnected;
            RegisterServiceEvents();
        }

        ~CatWebserviceWrapper()
        {
            if (Webservice.isLoggedIn()) Webservice.Logout();
            Webservice = null;
        }

        public WebserviceWrapperState WebserviceState { get; private set; }

        protected string Password
        {
            get { return Settings.Default.Webservice_Password; }
        }

        protected string UserName
        {
            get { return Settings.Default.Webservice_Username; }
        }

        private IImport Webservice { get; set; }

        public WebserviceResult Connect()
        {
            var info = new RequestInfo("Connect");
            WebserviceState = WebserviceWrapperState.Connecting;
            bool login = Webservice.Login(UserName, Password);
            var result = new WebserviceResult(info, login);
            WebserviceState = WebserviceWrapperState.Connected;
            return result;
        }

        public void ConnectAsync(Action<WebserviceResult> callback)
        {
            var requestInfo = new AsyncRequestInfo("ConnectAsnyc", callback);
            WebserviceState = WebserviceWrapperState.Connecting;
            Webservice.LoginAsync(UserName, Password, requestInfo);
        }

        public WebserviceResult Disconnect()
        {
            var info = new RequestInfo("Disconnect");
            WebserviceState = WebserviceWrapperState.Disconnecting;
            bool logout = Webservice.Logout();
            WebserviceState = WebserviceWrapperState.Disconnected;
            return new WebserviceResult(info, logout);
        }

        public void DisconnectAsync(Action<WebserviceResult> callback)
        {
            var requestInfo = new AsyncRequestInfo("DisconnectAsync", callback);
            WebserviceState = WebserviceWrapperState.Disconnecting;
            Webservice.LogoutAsync(requestInfo);
            WebserviceState = WebserviceWrapperState.Disconnected;
        }

        public string GetLoginStatus()
        {
            return Webservice.GetLoginStatus();
        }

        private static void InvokeAsyncRequestCallback(AsyncRequestInfo asyncRequestInfo, object[] objects,
                                                       Exception exception)
        {
            if (asyncRequestInfo == null)
            {
                throw new NullReferenceException("asyncRequestInfo was null.");
            }
            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, objects, exception));
        }

        private void InvokeAsyncRequestCallback(AsyncRequestInfo asyncRequestInfo, string result, Exception exception)
        {
            InvokeAsyncRequestCallback(asyncRequestInfo, new object[] { true, result }, exception);
        }

        private void OnWebserviceOnGetLoginStatusCompleted(object service,
                                                           GetLoginStatusCompletedEventArgs loginStatusArgs)
        {
            InvokeAsyncRequestCallback(loginStatusArgs.UserState as AsyncRequestInfo, loginStatusArgs.Result,
                                       loginStatusArgs.Error);
        }

        private void OnWebserviceOnWritePriceCompleted(object sender, writePriceCompletedEventArgs e)
        {
            InvokeAsyncRequestCallback(e.UserState as AsyncRequestInfo, e.Result, e.Error);
        }

        private void RegisterServiceEvents()
        {
            Webservice.LoginCompleted += WebserviceLoginCompleted;
            Webservice.LogoutCompleted += WebserviceLogoutCompleted;
            Webservice.GetLoginStatusCompleted += OnWebserviceOnGetLoginStatusCompleted;
            Webservice.writePriceCompleted += OnWebserviceOnWritePriceCompleted;
        }

        private void WebserviceLoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LoginCompleted)");

            bool result = e.Result;
            if (result) WebserviceState = WebserviceWrapperState.Connected;

            Exception exception = e.Error;

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, result, exception));
        }

        private void WebserviceLogoutCompleted(object sender, LogoutCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LogoutCompleted)");

            if (e.Result) WebserviceState = WebserviceWrapperState.Disconnected;

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, e.Result, e.Error));
        }

        #region Prices

        public WebserviceResult DeleteAllPrices(int valor)
        {
            var info = new RequestInfo(string.Format("DeleteAllPricesForValor: {0}", valor));
            object[] deletePricesByValor = Webservice.deletePricesByValor(valor);
            return new WebserviceResult(info, deletePricesByValor);
        }

        public WebserviceResult DeleteAllPricesAsync(int valor, Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult WritePrice(PriceWebsiteDescription description)
        {
            var info = new RequestInfo(string.Format("WritePrice {0}", description));
            object[] writePrice = Webservice.writePrice(description.Valor, description.LastUpdated, description.Bid,
                                                        description.Ask);
            return new WebserviceResult(info, writePrice);
        }

        public void WritePriceAsync(PriceWebsiteDescription description, Action<WebserviceResult> callback)
        {
            var asyncRequestInfo = new AsyncRequestInfo("WritePriceAsync", callback);
            Webservice.writePriceAsync(description.Valor, description.LastUpdated, description.Bid, description.Ask,
                                       asyncRequestInfo);
        }

        public WebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description,
                                              Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult WriteProduct(ProductWebsiteDescription d)
        {
            var info = new RequestInfo(string.Format("WriteProduct {0}", d));

            object[] writeProduct = Webservice.writeProductV2(d.Valor, d.Name, d.Currency, d.CurrencyRisk, d.Dirty,
                                                              d.Guarantor, d.LeadManager, d.Issuer, d.AssetClass,
                                                              d.ProductCat, d.ProductType, d.ISIN, d.StockExchange,
                                                              d.Pricing, d.ValutaDate, d.EmissionPrice, d.Nominal,
                                                              d.RedemptionDate, d.StartFixationDate, d.EndFixationDate,
                                                              d.CouponObservation, d.CpGuaranteed,
                                                              d.ConditionalObservation, d.Text_Bed_Coupon, d.cpbedingt,
                                                              d.Floater, d.CPFloater, d.TextFloater, d.minCoupon,
                                                              d.maxCoupon, d.TextCoupon, d.CallData, d.EarlyRedemption,
                                                              d.TextEarlyRedemtpion, d.Cap, d.MaxPayback,
                                                              d.TextMaxPayback, d.Protection, d.ProtectionType,
                                                              d.MinPayback, d.Partizipation, d.PartizipationText,
                                                              d.Discount, d.MaxYield, d.bonuslevel, d.issuerNameShort,
                                                              d.ProductState, d.productKatId, d.productTypeId,
                                                              d.EmissionType, d.Symbol, d.SmallestTradeableUnit, d.s1t,
                                                              d.s1v, d.s2t, d.s2v, d.s3t, d.s3v, d.NameEn,
                                                              d.CurrencyRiskEn, d.AssetClassEn, d.ProductCatEn,
                                                              d.ProductTypeEn, d.PricingEn, d.CpGuaranteedEn,
                                                              d.cpbedingtEn, d.CPFloaterEn, d.CallDataEn,
                                                              d.EarlyRedemptionEn, d.CouponGuaranteed_En,
                                                              d.couponBedingtEn, d.textBedCoupon_En, d.FloaterEn,
                                                              d.TextFloaterEn, d.minCouponEn, d.maxCouponEn,
                                                              d.TextCouponEn, d.TextEarlyRedemtpionEn, d.capEn,
                                                              d.MaxPaybackEn, d.TextMaxPaybackEn, d.ProtectionEn,
                                                              d.MinPaybackEn, d.PartizipationEn, d.PartizipationTextEn,
                                                              d.DiscountEn, d.MaxYieldEn, d.bonuslevelEn, d.s1tEN,
                                                              d.s1vEn, d.s2tEn, d.s2vEn, d.s3tEn, d.s3vEn, d.HasEnglish);
            return new WebserviceResult(info, writeProduct);
        }

        #endregion Prices
    }
}