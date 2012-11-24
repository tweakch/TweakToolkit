using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public interface ICatWebserviceWrapper
    {
        WebserviceWrapperState WebserviceState { get; }

        WebserviceResult Connect();

        void ConnectAsync(Action<WebserviceResult> callback);

        WebserviceResult Disconnect();

        void DisconnectAsync(Action<WebserviceResult> callback);

        #region Price
        
        WebserviceResult WritePrice(PriceWebsiteDescription description);

        void WritePriceAsync(PriceWebsiteDescription description, Action<WebserviceResult> callback);

        WebserviceResult WritePriceCollection(IEnumerable<PriceWebsiteDescription> descriptions);

        void WritePriceCollectionAsync(IEnumerable<PriceWebsiteDescription> description, Action<WebserviceResult> callback);

        WebserviceResult DeleteAllPrices(int valor);

        WebserviceResult DeleteAllPricesAsync(int valor, Action<WebserviceResult> callback);

        #endregion

        #region Product

        WebserviceResult WriteProduct(ProductWebsiteDescription d);


        #endregion
    }
}