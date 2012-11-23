using System;
using Bloomberglp.Blpapi;
using Microsoft.Practices.Unity;
using TweakToolkit.Bloomberg.Common;
using TweakToolkit.Bloomberg.Wrapper.EventHandler;

namespace TweakToolkit.Bloomberg.Wrapper
{
    public class EventContext : ISessionEventDispatcher
    {
        private readonly string exceptionProcessorId = Guid.NewGuid().ToString();
        private readonly IUnityContainer strategiesContainer;

        public EventContext(BloombergSessionWrapper bloombergSessionWrapper)
        {
            SessionContext = bloombergSessionWrapper;
            strategiesContainer = new UnityContainer();

            RegisterDefaultBehaviour();
        }

        public BloombergSessionWrapper SessionContext { get; set; }

        public void ProcessEventDispatcher(Event eventObj, Session session)
        {
            string messages = "Received Event: " + eventObj.Type + ": " + Environment.NewLine;
            foreach (Message message in eventObj)
            {
                messages += message + " ";
            }

            ProcessEvent(eventObj, SessionContext);
        }

        private void RegisterDefaultBehaviour()
        {
            foreach (string enumValue in typeof(Event.EventType).GetEnumNames())
            {
                RegisterEventHandler<MiscEventEventHandler>(enumValue);
            }
            RegisterEventHandler<ExceptionEventHandler>(exceptionProcessorId);
        }

        private void RegisterEventHandler<T>(string type) where T : ISessionEventHandler
        {
            if (strategiesContainer.IsRegistered<T>())
            {
                var o = strategiesContainer.Resolve<T>();
                strategiesContainer.Teardown(o);
            }
            if (!strategiesContainer.IsRegistered<T>())
            {
                strategiesContainer.RegisterType<ISessionEventHandler, T>(type);
            }
        }

        public void RegisterEventHandler<T>(Event.EventType type) where T : ISessionEventHandler
        {
            RegisterEventHandler<T>(type.ToString());
        }

        private void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            try
            {
                var handler = strategiesContainer.Resolve<ISessionEventHandler>(eventObj.Type.ToString());
                if (handler != null) handler.ProcessEvent(eventObj, session);
            }
            catch (Exception ex)
            {
                // take ex and pass it to the event handler...
                //strategiesContainer.Resolve<ISessionEventHandler>(exceptionProcessorId).ProcessEvent(eventObj, session);
                Console.WriteLine(ex);
            }
        }
    }
}