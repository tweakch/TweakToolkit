using System.IO;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    public class ExceptionEventHandler : AEventHandlerBase
    {
        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            string messages = "--> inside the exception handler i received this: ";

            foreach (Message message in eventObj)
            {
                messages += message + " ";
            }
            string file = Directory.GetCurrentDirectory() + "\\bb_session_error.log";
        }
    }
}