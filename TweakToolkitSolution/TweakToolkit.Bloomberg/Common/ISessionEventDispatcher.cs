using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Common
{
    public interface ISessionEventDispatcher
    {
        void ProcessEventDispatcher(Event eventobject, Session session);
    }
}