using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.Bloomberg.Domain;

namespace TweakToolkit.Bloomberg.Test
{
    [TestClass]
    public class ReferenceDataFixture
    {
        [TestMethod]
        public void RequestInfoTest()
        {
            string referenceDataResponse = "";
            var handler = new BloombergReferenceDataHandlerMock(referenceDataResponse);
            string field = "PX_BID";
            string security = "DE000CZ36U01@CBED CORP";

            handler.AddField(field);
            handler.AddSecurity(security);

            Assert.AreEqual(1, handler.RequestInfo.Fields.Count);
            Assert.AreEqual(1, handler.RequestInfo.Tickers.Count);

            Assert.AreEqual(security, handler.RequestInfo.Tickers[0]);
            Assert.AreEqual(field, handler.RequestInfo.Fields[0]);
        }

        [TestMethod]
        public void ParseValidRequestTest()
        {
            string referenceDataResponse = "ReferenceDataResponse={}";

            var handler = new BloombergReferenceDataHandlerMock(referenceDataResponse);
            handler.AddField("PX_BID");
            handler.AddSecurity("DE000CZ36U01@CBED CORP");

            var response = new ReferenceDataResponse(handler.RequestInfo);

            var message = new TweakMessage();

            response.SaveMessage(message);

            Assert.AreEqual(1, handler.Fields.Count);
            Assert.AreEqual(1, handler.Tickers.Count);
            Assert.AreEqual(1, response.Fields.Count);
            Assert.AreEqual(1, response.Securities.Count);
        }

        private void HandleReferenceDataResponse(ReferenceDataResponse obj)
        {
            throw new NotImplementedException();
        }
    }
}