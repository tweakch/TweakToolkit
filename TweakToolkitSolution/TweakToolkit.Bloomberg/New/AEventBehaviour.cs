using System;
using System.Collections;
using System.Collections.Generic;
using Bloomberglp.Blpapi;
using EventHandler = Bloomberglp.Blpapi.EventHandler;

namespace TweakToolkit.Bloomberg.New
{
    public abstract class AEventBehaviour : Dictionary<Event.EventType, EventHandler>
    {
        public abstract event EventHandler<ServiceOpenedEventArgs> ServiceOpened;

        public void HandleEvent(Event eventObject, Session session)
        {
            this[eventObject.Type](eventObject,session);
        }

        public void Execute(Event eventobject, Session session)
        {
            if (ContainsKey(eventobject.Type))
            {
                this[eventobject.Type](eventobject, session);
            }
        }
    }
}