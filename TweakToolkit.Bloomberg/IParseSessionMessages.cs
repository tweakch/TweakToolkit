using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg
{
    public interface IParseSessionMessages
    {
        void Parse(BloombergSessionWrapper wrapper, Message response);
    }
}