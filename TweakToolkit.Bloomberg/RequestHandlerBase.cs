using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Common;

namespace TweakToolkit.Bloomberg
{
    public abstract class RequestHandlerBase<T> : ABloombergHandlerBase<T>, ISendRequest, IRequestSecurities
        where T : ABloombergHandlerBase<T>
    {
        protected RequestHandlerBase(DataService dataService)
            : base(dataService)
        {
            Securities = new List<string>();
            Fields = new List<string>();
        }

        public List<string> Fields { get; private set; }

        public List<string> Securities { get; private set; }

        public int FieldCount
        {
            get { return Fields.Count; }
        }

        public int SecurityCount
        {
            get { return Securities.Count; }
        }

        public void AddSecurity(string security)
        {
            Securities.Add(security);
        }

        public void AddField(string field)
        {
            if (!Fields.Contains(field)) Fields.Add(field);
        }

        public abstract void Clear();

        public abstract CorrelationID SendRequestAsync();
    }
}