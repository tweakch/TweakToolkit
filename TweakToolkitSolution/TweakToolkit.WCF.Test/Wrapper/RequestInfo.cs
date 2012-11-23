using System;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class RequestInfo
    {
        public RequestInfo(string operation)
        {
            RequestId = Guid.NewGuid();
            Opearation = operation;
        }

        public string Opearation { get; set; }
        public Guid RequestId { get; set; }
    }
}