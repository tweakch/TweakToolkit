using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.EntityFramework.WebsiteData;
using TweakToolkit.WCF.Test.CatWebservice;
using TweakToolkit.WCF.Test.Properties;
using TweakToolkit.WCF.Test.ServiceDomain;
using TweakToolkit.WCF.Test.Wrapper;

namespace TweakToolkit.WCF.Test
{
    [TestClass]
    public class CatWebserviceWrapperUnitTest
    {
        private static IImport Service
        {
            get { return new Import { CookieContainer = new CookieContainer() }; }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            if (!Settings.Default.CleanupAfterTestrun) return;

            var wrapper = new CatWebserviceWrapper(Service);
            wrapper.Connect();

            while (!wrapper.DeleteProduct(Settings.Default.TestProductValor).HasErrors) { }

            wrapper.Disconnect();
        }

        #region Barrier Functions

        [TestMethod]
        public void DeleteAllBarriersForExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteBarriers = wrapper.DeleteBarriers(Settings.Default.TestProductValor);
            Assert.IsFalse(deleteBarriers.HasErrors);
        }

        [TestMethod]
        public void DeleteAllBarriersForNonExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteBarriers = wrapper.DeleteBarriers(Settings.Default.InvalidValor);
            Assert.IsTrue(deleteBarriers.HasErrors);
        }

        [TestMethod]
        public void WriteAllBarriersForExistingValor()
        {
            List<BarrierWebsiteDescription> descriptions = TestHelper.GetBarrierWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeProduct = wrapper.WriteProduct(TestHelper.GetProductWebsiteDescription());
            Assert.IsFalse(writeProduct.HasErrors);

            IWebserviceResult writeBarriers = wrapper.WriteBarriers(Settings.Default.TestProductValor, descriptions);
            Assert.IsFalse(writeBarriers.HasErrors, writeBarriers.ServiceMessage);
        }

        [TestMethod]
        public void WriteAllBarriersForNonExistingValor()
        {
            List<BarrierWebsiteDescription> descriptions = TestHelper.GetBarrierWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeBarriers = wrapper.WriteBarriers(Settings.Default.InvalidValor, descriptions);
            Assert.IsFalse(writeBarriers.HasErrors, writeBarriers.ServiceMessage);
        }

        #endregion Barrier Functions

        #region BaseValue Functions

        [TestMethod]
        public void DeleteAllBaseValuesForExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteBaseValues = wrapper.DeleteBaseValues(Settings.Default.TestProductValor);
            Assert.IsFalse(deleteBaseValues.HasErrors);
        }

        [TestMethod]
        public void DeleteAllBaseValuesForNonExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteBaseValues = wrapper.DeleteBaseValues(Settings.Default.InvalidValor);
            Assert.IsTrue(deleteBaseValues.HasErrors);
        }

        [TestMethod]
        public void WriteAllBaseValuesForExistingValor()
        {
            List<BaseValueWebsiteDescription> descriptions = TestHelper.GetBaseValueWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeProduct = wrapper.WriteProduct(TestHelper.GetProductWebsiteDescription());
            Assert.IsFalse(writeProduct.HasErrors);

            IWebserviceResult writeBaseValues = wrapper.WriteBaseValues(Settings.Default.TestProductValor, descriptions);
            Assert.IsFalse(writeBaseValues.HasErrors, writeBaseValues.ServiceMessage);
        }

        [TestMethod]
        public void WriteAllBaseValuesForNonExistingValor()
        {
            List<BaseValueWebsiteDescription> descriptions = TestHelper.GetBaseValueWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeBaseValues = wrapper.WriteBaseValues(Settings.Default.InvalidValor, descriptions);
            Assert.IsFalse(writeBaseValues.HasErrors, writeBaseValues.ServiceMessage);
        }

        #endregion BaseValue Functions

        #region Event Functions

        [TestMethod]
        public void DeleteAllEventsForExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteEvents = wrapper.DeleteEvents(Settings.Default.TestProductValor);
            Assert.IsFalse(deleteEvents.HasErrors);
        }

        [TestMethod]
        public void DeleteAllEventsForNonExistingValor()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult deleteEvents = wrapper.DeleteEvents(Settings.Default.InvalidValor);
            Assert.IsTrue(deleteEvents.HasErrors);
        }

        [TestMethod]
        public void WriteAllEventsForExistingValor()
        {
            List<EventWebsiteDescription> descriptions = TestHelper.GetEventWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeProduct = wrapper.WriteProduct(TestHelper.GetProductWebsiteDescription());
            Assert.IsFalse(writeProduct.HasErrors);

            IWebserviceResult writeEvents = wrapper.WriteEvents(Settings.Default.TestProductValor, descriptions);
            Assert.IsFalse(writeEvents.HasErrors, writeEvents.ServiceMessage);
        }

        [TestMethod]
        public void WriteAllEventsForNonExistingValor()
        {
            List<EventWebsiteDescription> descriptions = TestHelper.GetEventWebsiteDescriptions();
            Assert.AreNotEqual(0, descriptions.Count());

            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult connect = wrapper.Connect();
            Assert.IsFalse(connect.HasErrors, connect.ServiceMessage);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult writeEvents = wrapper.WriteEvents(Settings.Default.InvalidValor, descriptions);
            Assert.IsFalse(writeEvents.HasErrors, writeEvents.ServiceMessage);
        }

        #endregion Event Functions

        #region File Functions

        [TestMethod]
        public void DeleteFileForValor()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void WriteFileForValor()
        {
            throw new NotImplementedException();
        }

        #endregion File Functions

        #region Price Functions

        [TestMethod]
        public void DeleteAllPrices()
        {
            throw new NotImplementedException();
            using (var db = new StruktoWebsiteEntities())
            {
            }
        }

        [TestMethod]
        public void DeleteAllPricesForValor()
        {
            PriceWebsiteDescription price = TestHelper.GetPriceWebsiteDescription();

            var wrapper = new CatWebserviceWrapper(Service);
            wrapper.Connect();

            IWebserviceResult webserviceResult = wrapper.WritePrice(price);
            Assert.IsFalse(webserviceResult.HasErrors, webserviceResult.ServiceMessage);
            wrapper.DeleteAllPrices(price.Valor);
        }

        [TestMethod]
        public void WritePriceForOnlineProductTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            PriceWebsiteDescription price = TestHelper.GetPriceWebsiteDescription();

            wrapper.Connect();

            IWebserviceResult webserviceResult = wrapper.WritePrice(price);
            Assert.IsFalse(webserviceResult.HasErrors);
            Assert.IsNotNull(webserviceResult.RequestInfo);
        }

        [TestMethod]
        public void WritePriceOnDisconnectedServiceTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            PriceWebsiteDescription price = TestHelper.GetPriceWebsiteDescription();
            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);

            IWebserviceResult webserviceResult = wrapper.WritePrice(price);

            Assert.IsTrue(webserviceResult.HasErrors);
            Assert.IsNotNull(webserviceResult.RequestInfo);
        }

        #endregion Price Functions

        #region Product Functions

        [TestMethod]
        public void DeleteNonExistingProductFromWebsite()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            ProductWebsiteDescription description = TestHelper.GetEmptyProductWebsiteDescription();
            wrapper.Connect();

            IWebserviceResult webserviceResult = wrapper.WriteProduct(description);
            Assert.IsTrue(webserviceResult.HasErrors, webserviceResult.ServiceMessage);
        }

        [TestMethod]
        public void PublishUnpublishProductWithReadData()
        {
            ProductWebsiteDescription description = TestHelper.GetProductWebsiteDescription();

            var wrapper = new CatWebserviceWrapper(Service);
            wrapper.Connect();

            IWebserviceResult writeProduct = wrapper.WriteProduct(description);
            Assert.IsFalse(writeProduct.HasErrors);

            IWebserviceResult deleteProduct = wrapper.DeleteProduct(description.Valor);
            Assert.IsFalse(deleteProduct.HasErrors);
        }

        [TestMethod]
        public void WriteProductWithEmptyDescription()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            wrapper.Connect();

            IWebserviceResult webserviceResult = wrapper.WriteProduct(TestHelper.GetEmptyProductWebsiteDescription());
            Assert.IsTrue(webserviceResult.HasErrors, webserviceResult.ServiceMessage);
        }

        #endregion Product Functions

        #region Service Functions

        [TestMethod]
        public void AsyncConnectDisconnectTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);

            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
            bool waiting = true;

            wrapper.ConnectAsync(
                connect =>
                {
                    Assert.AreEqual(WebserviceWrapperState.Connected, wrapper.WebserviceState);
                    wrapper.DisconnectAsync(
                        disconnect =>
                        {
                            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
                            waiting = false;
                        });
                });

            while (waiting)
            {
                Thread.Sleep(200);
            }
        }

        [TestMethod]
        public void AsyncWebserviceResultExceptionTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            bool wait = true;

            wrapper.WritePriceAsync(
                TestHelper.GetPriceWebsiteDescription(),
                asyncResult =>
                {
                    Assert.IsTrue(asyncResult.HasErrors);
                    Assert.IsNotNull(asyncResult.ServiceMessage, asyncResult.ServiceMessage);
                    wait = false;
                });

            while (wait)
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

            IWebserviceResult connect = wrapper.Connect();
            Assert.AreEqual(WebserviceWrapperState.Connected, wrapper.WebserviceState);
            Assert.IsFalse(connect.HasErrors);
            Assert.IsTrue(wrapper.IsConnected);

            IWebserviceResult disconnect = wrapper.Disconnect();
            Assert.AreEqual(WebserviceWrapperState.Disconnected, wrapper.WebserviceState);
            Assert.IsFalse(disconnect.HasErrors);
            Assert.IsFalse(wrapper.IsConnected);
        }

        [TestMethod]
        public void WebserviceResultExceptionTest()
        {
            var wrapper = new CatWebserviceWrapper(Service);
            IWebserviceResult result = wrapper.WritePrice(TestHelper.GetPriceWebsiteDescription());
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.ServiceMessage, result.ServiceMessage);
        }

        #endregion Service Functions
    }
}