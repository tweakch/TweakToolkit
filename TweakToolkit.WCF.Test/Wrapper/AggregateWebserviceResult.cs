using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweakToolkit.WCF.Test.Wrapper
{
    public class AggregateWebserviceResult : WebserviceResult
    {
        private List<IWebserviceResult> _results;

        public AggregateWebserviceResult(RequestInfo info)
            : base(info, false)
        {
        }

        public override bool HasErrors
        {
            get { return Results.Any(result => result.HasErrors); }
        }

        public override string ServiceMessage
        {
            get
            {
                var builder = new StringBuilder();
                foreach (WebserviceResult result in Results)
                {
                    builder.AppendLine(result.ServiceMessage);
                }
                return builder.ToString();
            }
        }

        public List<IWebserviceResult> Results
        {
            get { return _results ?? (_results = new List<IWebserviceResult>()); }
        }

        internal void Add(object[] p)
        {
            Add(new WebserviceResult(RequestInfo, p));
        }

        internal void Add(IWebserviceResult result)
        {
            Results.Add(result);
        }
    }
}