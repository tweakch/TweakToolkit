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
            var login = Webservice.Login(UserName, Password);
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
            var logout = Webservice.Logout();
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

        #region Prices

        public WebserviceResult DeleteAllPrices(int valor)
        {
            var info = new RequestInfo(string.Format("DeleteAllPricesForValor: {0}", valor));
            var deletePricesByValor = Webservice.deletePricesByValor(valor);
            return new WebserviceResult(info, deletePricesByValor);
        }

        public WebserviceResult DeleteAllPricesAsync(int valor, Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult WritePrice(PriceDescription description)
        {
            var info = new RequestInfo(string.Format("WritePrice {0}", description));
            var writePrice = Webservice.writePrice(description.Valor, description.LastUpdated, description.Bid, description.Ask);
            return new WebserviceResult(info, writePrice);
        }

        public void WritePriceAsync(PriceDescription description, Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult WritePriceCollection(IEnumerable<PriceDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public void WritePriceCollectionAsync(IEnumerable<PriceDescription> description, Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        #endregion Prices

        private void RegisterServiceEvents()
        {
            Webservice.LoginCompleted += WebserviceLoginCompleted;
            Webservice.LogoutCompleted += WebserviceLogoutCompleted;
            Webservice.GetLoginStatusCompleted += Webservice_GetLoginStatusCompleted;
        }

        private void Webservice_GetLoginStatusCompleted(object sender, GetLoginStatusCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WebserviceLoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LoginCompleted)");

            if (e.Result) WebserviceState = WebserviceWrapperState.Connected;

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, e.Result, e.Error));
        }

        private void WebserviceLogoutCompleted(object sender, LogoutCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LogoutCompleted)");

            if (e.Result) WebserviceState = WebserviceWrapperState.Disconnected;

            asyncRequestInfo.Callback(new WebserviceResult(asyncRequestInfo, e.Result, e.Error));
        }
    }
}