using System;

namespace TweakToolkit.MVVM.Gateway.Exceptions
{
    public class UnknownEntityException : Exception
    {
        public UnknownEntityException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}