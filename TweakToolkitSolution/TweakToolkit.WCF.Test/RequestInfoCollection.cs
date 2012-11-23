using System.Collections.Generic;

namespace TweakToolkit.WCF.Test
{
    internal class RequestInfoCollection
    {
        public RequestInfoCollection()
        {
            requestInfos = new List<RequestInfo>();
        }
        
        private List<RequestInfo> requestInfos;

        public void Add(RequestInfo message)
        {
            requestInfos.Add(message);
        }
    }
}