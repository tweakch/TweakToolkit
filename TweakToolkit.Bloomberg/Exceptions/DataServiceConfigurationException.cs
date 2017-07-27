using System;

namespace TweakToolkit.Bloomberg.Exceptions
{
    public class DataServiceConfigurationException : Exception
    {
        private const string ErrorMessageDataServiceConfigurationException
            = "SetDataService(ServiceType service) must be called before subscription";

        public DataServiceConfigurationException()
            : base(ErrorMessageDataServiceConfigurationException)
        {
        }
    }
}