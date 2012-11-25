using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public interface ICatWebserviceWrapper
    {
        #region Price

        #endregion Price

        #region Product

        #endregion Product

        WebserviceWrapperState WebserviceState { get; }

        bool IsConnected { get; }

        IWebserviceResult Connect();

        void ConnectAsync(Action<IWebserviceResult> callback);

        IWebserviceResult Disconnect();

        void DisconnectAsync(Action<IWebserviceResult> callback);

        string GetLoginStatus();

        IWebserviceResult DeleteEvents(int valor);

        IWebserviceResult WriteEvents(int valor, IEnumerable<EventWebsiteDescription> descriptions);

        IWebserviceResult DeleteBarriers(int valor);

        IWebserviceResult WriteBarriers(int valor, IEnumerable<BarrierWebsiteDescription> descriptions);

        IWebserviceResult DeleteAllPrices(int valor);

        IWebserviceResult DeleteAllPricesAsync(int valor, Action<IWebserviceResult> callback);

        IWebserviceResult WritePrice(PriceWebsiteDescription description);

        void WritePriceAsync(PriceWebsiteDescription description, Action<IWebserviceResult> callback);

        IWebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions);

        void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description,
                                                       Action<IWebserviceResult> callback);

        IWebserviceResult DeleteProduct(int valor);

        IWebserviceResult WriteProduct(ProductWebsiteDescription d);
    }
}