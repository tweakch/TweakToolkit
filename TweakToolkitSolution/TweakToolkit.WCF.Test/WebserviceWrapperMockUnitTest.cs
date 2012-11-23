using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.WCF.Test.CatWebservice;

namespace TweakToolkit.WCF.Test
{
    [TestClass]
    public class WebserviceWrapperMockUnitTest
    {
        private static IImport _service;

        [TestInitialize]
        public static void TestInitialize(TestContext context)
        {
            _service = new ImportMock { CookieContainer = new CookieContainer() };
        }

        [TestMethod]
        public void SyncConnectDisconnectTest()
        {
            var wrapper = new CatWebserviceWrapper(_service);
            Assert.AreEqual(WebserviceState.Disconnected, wrapper.WebserviceState);

            var connect = wrapper.Connect();
            Assert.AreEqual(WebserviceState.Connected, wrapper.WebserviceState);
            Assert.IsTrue(connect.Result);

            var disconnect = wrapper.Disconnect();
            Assert.AreEqual(WebserviceState.Disconnected, wrapper.WebserviceState);
            Assert.IsTrue(disconnect.Result);
        }

        [TestMethod]
        public void AsyncConnectDisconnectTest()
        {
            var wrapper = new CatWebserviceWrapper(_service);

            Assert.AreEqual(WebserviceState.Disconnected, wrapper.WebserviceState);
            var waiting = true;

            wrapper.ConnectAsync(
                result => Assert.AreEqual(WebserviceState.Connected, wrapper.WebserviceState));

            wrapper.DisconnectAsync(
                result =>
                    {
                        Assert.AreEqual(WebserviceState.Disconnected, wrapper.WebserviceState);
                        waiting = false;
                    });

            while (waiting)
            {
                Thread.Sleep(200);
            }
        }
    }
}