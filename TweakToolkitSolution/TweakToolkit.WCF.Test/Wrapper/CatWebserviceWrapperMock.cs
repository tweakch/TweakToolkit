using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class CatWebserviceWrapperMock : ICatWebserviceWrapper
    {
        public WebserviceWrapperState WebserviceState { get; private set; }

        public bool IsConnected { get; private set; }

        public IWebserviceResult Connect()
        {
            return new WebserviceResult(new RequestInfo("Connect"), new object[] { false });
        }

        public void ConnectAsync(Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult Disconnect()
        {
            return new WebserviceResult(new RequestInfo("Disconnect"), new object[] { false });
        }

        public void DisconnectAsync(Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public string GetLoginStatus()
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult DeleteEvents(int valor)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WriteEvents(int valor, IEnumerable<EventWebsiteDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult DeleteBarriers(int valor)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WriteBarriers(int valor, IEnumerable<BarrierWebsiteDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WritePrice(PriceWebsiteDescription description)
        {
            throw new NotImplementedException();
        }

        public void WritePriceAsync(PriceWebsiteDescription description, Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description, Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult DeleteProduct(int valor)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult DeleteAllPrices(int valor)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult DeleteAllPricesAsync(int valor, Action<IWebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public IWebserviceResult WriteProduct(ProductWebsiteDescription d)
        {
            throw new NotImplementedException();
        }
    }
}