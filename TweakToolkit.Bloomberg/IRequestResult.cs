using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg
{
    public interface IRequestResult
    {
        Dictionary<string, Dictionary<string, string>> GetResultsForCorrelationId(CorrelationID correlationId);

        Dictionary<string, string> GetResultsForTicker(string issuerTicker);
    }
}