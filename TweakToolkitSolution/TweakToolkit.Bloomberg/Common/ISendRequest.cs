using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Common
{
    internal interface ISendRequest
    {
        CorrelationID SendRequestAsync();
    }
}