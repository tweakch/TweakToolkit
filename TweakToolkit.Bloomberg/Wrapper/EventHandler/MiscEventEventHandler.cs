using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    internal class MiscEventEventHandler : AEventHandlerBase
    {
        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            Console.WriteLine("Processor " + id + ": Processing " + eventObj.Type);
            foreach (Message msg in eventObj)
            {
                Console.WriteLine(DateTime.Now.ToString("s") +
                                  ": " + msg.MessageType + "\n");
            }
        }
    }
}