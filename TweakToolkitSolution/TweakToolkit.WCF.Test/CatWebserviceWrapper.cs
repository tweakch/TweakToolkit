using System;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.Properties;

namespace TweakToolkit.WCF.Test
{
    public class CatWebserviceWrapper : ICatWebserviceWrapper
    {
        private readonly RequestInfoCollection _requestInfoCollection = new RequestInfoCollection();
        private RequestResultCollection _requestResultCollection = new RequestResultCollection();

        public CatWebserviceWrapper(IImport service)
        {
            Webservice = service;
            WebserviceState = WebserviceState.Disconnected;
            RegisterServiceEvents();
        }

        public WebserviceState WebserviceState { get; private set; }

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
            WebserviceState = WebserviceState.Connecting;
            var login = Webservice.Login(UserName, Password);
            var result = new WebserviceResult(login, null, false, info);
            WebserviceState = WebserviceState.Connected;
            return result;
        }

        public void ConnectAsync(Action<WebserviceResult> callback)
        {
            var requestInfo = new AsyncRequestInfo("ConnectAsnyc", callback);
            WebserviceState = WebserviceState.Connecting;
            Webservice.LoginAsync(UserName, Password, requestInfo);
        }

        public WebserviceResult Disconnect()
        {
            var info = new RequestInfo("Disconnect");
            WebserviceState = WebserviceState.Disconnecting;
            var logout = Webservice.Logout();
            WebserviceState = WebserviceState.Disconnected;
            return new WebserviceResult(logout, null, false, info);
        }

        public void DisconnectAsync(Action<WebserviceResult> callback)
        {
            var requestInfo = new AsyncRequestInfo("DisconnectAsync", callback);
            WebserviceState = WebserviceState.Disconnecting;
            Webservice.LogoutAsync(requestInfo);
            WebserviceState = WebserviceState.Disconnected;
        }

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

            if (e.Result) WebserviceState = WebserviceState.Connected;

            asyncRequestInfo.Callback(new WebserviceResult(e.Result, e.Error, e.Cancelled, asyncRequestInfo));
        }

        private void WebserviceLogoutCompleted(object sender, LogoutCompletedEventArgs e)
        {
            var asyncRequestInfo = e.UserState as AsyncRequestInfo;
            if (asyncRequestInfo == null) throw new NullReferenceException("asyncRequestInfo (LogoutCompleted)");

            if (e.Result) WebserviceState = WebserviceState.Disconnected;

            asyncRequestInfo.Callback(new WebserviceResult(e.Result, e.Error, e.Cancelled, asyncRequestInfo));
        }

        public string GetLoginStatus()
        {
            return Webservice.GetLoginStatus();
        }
    }
}