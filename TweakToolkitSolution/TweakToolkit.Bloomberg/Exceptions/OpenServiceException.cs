using System;

namespace TweakToolkit.Bloomberg.Exceptions
{
    public class OpenServiceException : Exception
    {
        public OpenServiceException(DataService service)
            : base("Failed to open service " + service)
        {
        }

        public OpenServiceException(Exception service)
            : base("Failed to open service " + service, service)
        {
        }
    }
}