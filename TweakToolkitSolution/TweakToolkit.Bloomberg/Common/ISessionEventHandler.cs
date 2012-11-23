using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Wrapper;

namespace TweakToolkit.Bloomberg.Common
{
    public interface ISessionEventHandler
    {
        void ProcessEvent(Event eventObj, BloombergSessionWrapper session);
    }
}