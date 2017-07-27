using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public class UnknownCorrelationIdException : Exception
    {
        public CorrelationID UnknownId { get; set; }

        public UnknownCorrelationIdException(CorrelationID correlationId)
        {
            UnknownId = correlationId;
        }
    }
}