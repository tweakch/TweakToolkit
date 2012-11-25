using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.Properties;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class CatWebserviceWrapper : ICatWebserviceWrapper
    {
        #region ctor

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

        #endregion ctor

        #region Fields

        #endregion Fields

        #region Properties

        protected string Password
        {
            get { return Settings.Default.Webservice_Password; }
        }

        protected string UserName
        {
            get { return Settings.Default.Webservice_Username; }
        }

        private IImport Webservice { get; set; }

        public bool IsConnected
        {
            get { return GetLoginStatus().Equals("Logged In"); }
        }

        public WebserviceWrapperState WebserviceState { get; private set; }

        #endregion Properties

        #region Service Methods

        public IWebserviceResult Connect()
        {
            var info = new RequestInfo("Connect");
            WebserviceState = WebserviceWrapperState.Connecting;
            bool login = Webservice.Login(UserName, Password);
            var result = new WebserviceResult(info, login);
            WebserviceState = WebserviceWrapperState.Connected;
            return result;
        }

        public void ConnectAsync(Action<IWebserviceResult> callback)
        {
            var requestInfo = new AsyncRequestInfo("ConnectAsnyc", callback);
            WebserviceState = WebserviceWrapperState.Connecting;
            Webservice.LoginAsync(UserName, Password, requestInfo);
        }

        public IWebserviceResult Disconnect()
        {
            var info = new RequestInfo("Disconnect");
            WebserviceState = WebserviceWrapperState.Disconnecting;
            bool logout = Webservice.Logout();
            WebserviceState = WebserviceWrapperState.Disconnected;
            return new WebserviceResult(info, logout);
        }

        public void DisconnectAsync(Action<IWebserviceResult> callback)
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

        private void OnWebserviceOnGetLoginStatusCompleted(object service,
                                                           GetLoginStatusCompletedEventArgs loginStatusArgs)
        {
            InvokeAsyncRequestCallback(loginStatusArgs.UserState as AsyncRequestInfo, loginStatusArgs.Result,
                                       loginStatusArgs.Error);
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

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, result));
        }

        private void WebserviceLogoutCompleted(object sender, LogoutCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LogoutCompleted)");

            if (e.Result) WebserviceState = WebserviceWrapperState.Disconnected;

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, e.Result));
        }

        #endregion Service Methods

        #region Barrier Methods

        public IWebserviceResult DeleteBarriers(int valor)
        {
            var operation = string.Format("DeleteBarriers for {0}", valor);
            return WebserviceResult.Create(operation, Webservice.deleteBarrageOfProductByValor(valor));
        }

        public IWebserviceResult WriteBarrier(int valor, BarrierWebsiteDescription description)
        {
            string requestInfo = string.Format("WriteBarrier for {0}", valor);
            return WebserviceResult.Create(requestInfo,
                                           Webservice.writeBarrage(description.Valor, description.Name,
                                                                   description.Barrier,
                                                                   description.Trigger, description.Observation,
                                                                   description.Settlement,
                                                                   description.NameEn, description.TriggerEn,
                                                                   description.ObservationEn,
                                                                   description.SettlementEn));
        }

        public IWebserviceResult WriteBarriers(int valor, IEnumerable<BarrierWebsiteDescription> descriptions)
        {
            var info = new RequestInfo(string.Format("WriteBarriers for {0}", valor));
            var result = new AggregateWebserviceResult(info);
            foreach (BarrierWebsiteDescription description in descriptions)
            {
                result.Add(WriteBarrier(valor, description));
            }
            return result;
        }

        #endregion Barrier Methods

        #region BaseValue Methods

        public IWebserviceResult DeleteBaseValues(int valor)
        {
            string requestInfo = string.Format("DeleteEvents for {0}", valor);
            return WebserviceResult.Create(requestInfo, Webservice.deleteBasevaluesOfProductByValor(valor));
        }

        public IWebserviceResult WriteBaseValue(int valor, BaseValueWebsiteDescription description)
        {
            string operation = string.Format("WriteBaseValue for {0}", valor);
            return WebserviceResult.Create(operation, Webservice.writeBasevalue(description.Valor, description.Name));
        }

        public IWebserviceResult WriteBaseValues(int valor, IEnumerable<BaseValueWebsiteDescription> descriptions)
        {
            var info = new RequestInfo(string.Format("WriteBarriers for {0}", valor));
            var result = new AggregateWebserviceResult(info);
            foreach (BaseValueWebsiteDescription description in descriptions)
            {
                result.Add(WriteBaseValue(valor, description));
            }
            return result;
        }

        #endregion BaseValue Methods

        #region Event Methods

        public IWebserviceResult DeleteEvents(int valor)
        {
            var operation = string.Format("DeleteEvents for {0}", valor);
            return WebserviceResult.Create(operation, Webservice.deleteEventsOfProductByValor(valor));
        }

        public IWebserviceResult WriteEvent(int valor, EventWebsiteDescription description)
        {
            var operation = string.Format("WriteEvent for {0}", valor);
            return WebserviceResult.Create(operation, Webservice.writeEvent(description.Valor, description.ObservationDate, description.EventType,
                                                 description.EventValutaDate,
                                                 description.PeriodName, description.PeriodStart, description.PeriodEnd,
                                                 description.Description, description.EventTypeEn,
                                                 description.PeriodNameEn, description.DescriptionEn));
        }

        public IWebserviceResult WriteEvents(int valor, IEnumerable<EventWebsiteDescription> descriptions)
        {
            var info = new RequestInfo(string.Format("WriteEvents for {0}", valor));
            var result = new AggregateWebserviceResult(info);
            foreach (EventWebsiteDescription description in descriptions)
            {
                result.Add(WriteEvent(valor, description));
            }
            return result;
        }

        #endregion Event Methods

        #region Price Methods

        public IWebserviceResult DeleteAllPrices(int valor)
        {
            var info = new RequestInfo(string.Format("DeleteAllPricesForValor: {0}", valor));
            object[] deletePricesByValor = Webservice.deletePricesByValor(valor);
            return new WebserviceResult(info, deletePricesByValor);
        }

        public IWebserviceResult DeleteAllPricesAsync(int valor, Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WritePrice(PriceWebsiteDescription description)
        {
            var info = new RequestInfo(string.Format("WritePrice {0}", description));
            object[] writePrice = Webservice.writePrice(description.Valor, description.LastUpdated, description.Bid,
                                                        description.Ask);
            return new WebserviceResult(info, writePrice);
        }

        public void WritePriceAsync(PriceWebsiteDescription description, Action<IWebserviceResult> callback)
        {
            var asyncRequestInfo = new AsyncRequestInfo("WritePriceAsync", callback);
            Webservice.writePriceAsync(description.Valor, description.LastUpdated, description.Bid, description.Ask,
                                       asyncRequestInfo);
        }

        public IWebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description,
                                              Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        private void OnWebserviceOnWritePriceCompleted(object sender, writePriceCompletedEventArgs e)
        {
            InvokeAsyncRequestCallback(e.UserState as AsyncRequestInfo, e.Result, e.Error);
        }

        #endregion Price Methods

        #region Product Methods

        public IWebserviceResult DeleteProduct(int valor)
        {
            var info = new RequestInfo("Delete product " + valor);
            object[] deleteProduct = Webservice.deleteProductByValor(valor);
            return new WebserviceResult(info, deleteProduct);
        }

        public IWebserviceResult WriteProduct(ProductWebsiteDescription d)
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

        #endregion Product Methods

        #region Helper Methods

        private static void InvokeAsyncRequestCallback(AsyncRequestInfo asyncRequestInfo, object[] objects,
                                                       Exception exception)
        {
            if (exception != null)
            {
                throw new NotImplementedException("Unknown exception occurred.", exception);
            }

            if (asyncRequestInfo == null)
            {
                throw new NullReferenceException("asyncRequestInfo was null.");
            }

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, objects));
        }

        private void InvokeAsyncRequestCallback(AsyncRequestInfo asyncRequestInfo, string result, Exception exception)
        {
            InvokeAsyncRequestCallback(asyncRequestInfo, new object[] { true, result }, exception);
        }

        #endregion Helper Methods
    }
}