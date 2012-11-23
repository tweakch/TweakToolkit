﻿using System;
using System.Collections.Generic;
using TweakToolkit.WCF.Test.ServiceDomain;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class UnavailableWebserviceWrapperMock : ICatWebserviceWrapper
    {
        public WebserviceWrapperState WebserviceState { get; private set; }

        public WebserviceResult Connect()
        {
            return new WebserviceResult(new RequestInfo("Connect"), new object[]{false});
        }

        public void ConnectAsync(Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult Disconnect()
        {
            return new WebserviceResult(new RequestInfo("Disconnect"), new object[] { false });
        }

        public void DisconnectAsync(Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult WritePrice(PriceDescription description)
        {
            throw new NotImplementedException();
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

        public WebserviceResult DeleteAllPrices(int valor)
        {
            throw new NotImplementedException();
        }

        public WebserviceResult DeleteAllPricesAsync(int valor, Action<WebserviceResult> callback)
        {
            throw new NotImplementedException();
        }
    }
}