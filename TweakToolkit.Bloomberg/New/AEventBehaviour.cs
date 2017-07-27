using System;
using System.Collections;
using System.Collections.Generic;
using Bloomberglp.Blpapi;
using EventHandler = Bloomberglp.Blpapi.EventHandler;

namespace TweakToolkit.Bloomberg.New
{
    public abstract class ASessionBehaviourBase : Dictionary<Event.EventType, EventHandler>
    {
        public abstract event EventHandler<ServiceOpenedEventArgs> ServiceOpened;

        public void HandleEvent(Event eventObject, Session session)
        {
            this[eventObject.Type](eventObject,session);
        }

        public void Execute(Event eventObject, Session session)
        {
            if (ContainsKey(eventObject.Type))
            {
                this[eventObject.Type](eventObject, session);
            }
            else
            {
                foreach (var item in eventObject)
	            {
                    var msg = item.ToString();
                    Console.WriteLine(msg);
	            }
            }
        }
    }
}