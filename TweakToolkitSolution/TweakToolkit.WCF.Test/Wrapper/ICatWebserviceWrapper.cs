using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public interface ICatWebserviceWrapper
    {
        bool IsConnected { get; }

        WebserviceWrapperState WebserviceState { get; }

        IWebserviceResult Connect();

        void ConnectAsync(Action<IWebserviceResult> callback);

        IWebserviceResult DeleteAllPrices(int valor);

        IWebserviceResult DeleteAllPricesAsync(int valor, Action<IWebserviceResult> callback);

        IWebserviceResult DeleteBarriers(int valor);

        IWebserviceResult DeleteBaseValues(int valor);

        IWebserviceResult DeleteEvents(int valor);

        IWebserviceResult DeleteFile(string fileName);

        IWebserviceResult DeleteProduct(int valor);

        IWebserviceResult Disconnect();

        void DisconnectAsync(Action<IWebserviceResult> callback);

        string GetLoginStatus();

        IWebserviceResult SaveFile(int valor, FileWebsiteDescription description);

        IWebserviceResult WriteBarrier(int valor, BarrierWebsiteDescription description);

        IWebserviceResult WriteBarriers(int valor, IEnumerable<BarrierWebsiteDescription> descriptions);

        IWebserviceResult WriteBaseValue(int valor, BaseValueWebsiteDescription description);

        IWebserviceResult WriteBaseValues(int valor, IEnumerable<BaseValueWebsiteDescription> descriptions);

        IWebserviceResult WriteEvent(int valor, EventWebsiteDescription description);

        IWebserviceResult WriteEvents(int valor, IEnumerable<EventWebsiteDescription> descriptions);

        IWebserviceResult WriteIssuerRating(int issuerId, IssuerRatingWebsiteDescription description);

        IWebserviceResult WritePrice(PriceWebsiteDescription description);

        void WritePriceAsync(PriceWebsiteDescription description, Action<IWebserviceResult> callback);

        IWebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions);

        void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description,
                                                       Action<IWebserviceResult> callback);

        IWebserviceResult WriteProduct(ProductWebsiteDescription d);
    }
}