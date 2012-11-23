﻿using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.ServiceDomain;
using TweakToolkit.WCF.Test.Wrapper;

namespace TweakToolkit.WCF.Test
{
    [TestClass]
    public class WebserviceWrapperMockUnitTest
    {
        private static IImport Service
        {
            get { return new Import { CookieContainer = new CookieContainer() }; }
        }

        #region Price Functions

        [TestMethod]
        public void WritePriceForOnlineProductTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            var price = new PriceDescription();
            wrapper.Connect();

            var webserviceResult = wrapper.WritePrice(price);
            Assert.IsTrue(webserviceResult.Completed);
            Assert.IsNull(webserviceResult.ServiceException);
            Assert.IsNotNull(webserviceResult.RequestInfo);
        }

        [TestMethod]
        public void WritePriceOnDisconnectedServiceTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            var price = new PriceDescription();
            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);

            var webserviceResult = wrapper.WritePrice(price);

            Assert.IsFalse(webserviceResult.Completed);
            Assert.IsNotNull(webserviceResult.ServiceException);
            Assert.IsNotNull(webserviceResult.RequestInfo);
        }

        [TestMethod]
        public void DeleteAllPricesForValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            var price = new PriceDescription();
            wrapper.Connect();

            var webserviceResult = wrapper.WritePrice(price);
            
            Assert.IsTrue(webserviceResult.Completed);
            wrapper.DeleteAllPrices(price.Valor);
        }

        #endregion Price Functions

        #region Service Functions

        [TestMethod]
        public void AsyncConnectDisconnectTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);

            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
            var waiting = true;

            wrapper.ConnectAsync(
                result => Assert.AreEqual(WebserviceWrapperState.Connected, wrapper.WebserviceState));

            wrapper.DisconnectAsync(
                result =>
                {
                    Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
                    waiting = false;
                });

            while (waiting)
            {
                Thread.Sleep(200);
            }
        }

        [TestMethod]
        public void GetLoginStatusTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);

            wrapper.Connect();
            Assert.AreEqual("Logged In", wrapper.GetLoginStatus());

            wrapper.Disconnect();
            Assert.AreEqual("Not Logged In", wrapper.GetLoginStatus());
        }

        [TestMethod]
        public void SyncConnectDisconnectTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);

            var connect = wrapper.Connect();
            Assert.AreEqual(WebserviceWrapperState.Connected, wrapper.WebserviceState);
            Assert.IsTrue(connect.Completed);

            var disconnect = wrapper.Disconnect();
            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
            Assert.IsTrue(disconnect.Completed);
        }

        #endregion Service Functions
    }
}