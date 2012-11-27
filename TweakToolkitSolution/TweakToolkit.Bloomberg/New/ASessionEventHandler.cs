using System.Collections;
using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.New
{
    public abstract class ASessionEventHandler
    {
        //protected virtual void HandleEvent(Event eventObj)
        //{
        //    var eventType = eventObj.Type;
        //    if (handlers.ContainsKey(eventType))
        //    {
        //        handlers[eventType](eventObj);
        //    }
        //    else
        //    {
        //        System.Console.WriteLine("Processing " + eventObj.Type);
        //        foreach (Message msg in eventObj)
        //        {
        //            System.Console.WriteLine(System.DateTime.Now.ToString("s") +
        //                ": " + msg.MessageType + "\n");
        //        }
        //    }
        //}
        
        public abstract void RegisterSession(SessionBase sessionBase);
    }
}