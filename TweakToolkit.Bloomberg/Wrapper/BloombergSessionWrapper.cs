using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;
using MyToolkit.MVVM;
using TweakToolkit.Bloomberg.Common;

namespace TweakToolkit.Bloomberg.Wrapper
{
    public class BloombergSessionWrapper : NotifyPropertyChanged<ISession>, ISession
    {
        private readonly Session session;
        private readonly SessionOptions sessionOptions;

        private string host;

        private int port;

        public BloombergSessionWrapper()
        {
            Console.WriteLine("Initializing session");
            Context = new EventContext(this);
            Host = "localhost";
            Port = 8194;
            RequestDescriptions = new Dictionary<CorrelationID, ReferenceDataRequestInfo>();
            sessionOptions = new SessionOptions
                                 {
                                     ServerHost = Host,
                                     ServerPort = Port
                                 };

            Console.WriteLine("Connecting to " + Host + ":" + Port);
            session = new Session(sessionOptions, Context.ProcessEventDispatcher);
        }

        public Dictionary<CorrelationID, ReferenceDataRequestInfo> RequestDescriptions { get; private set; }

        protected EventContext Context { get; set; }

        protected string ServiceHost { get; set; }

        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                RaisePropertyChanged(m => m.Host);
            }
        }

        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                RaisePropertyChanged(m => m.Port);
            }
        }

        public bool Start()
        {
            return session.Start();
        }

        public void Stop()
        {
            session.Stop();
        }

        public Service GetService()
        {
            Console.WriteLine("Getting service: " + ServiceHost);
            return session.GetService(ServiceHost);
        }

        public bool OpenService(string serviceHost)
        {
            ServiceHost = serviceHost;
            return session.OpenService(ServiceHost);
        }

        public void RegisterEventHandler<T>(Event.EventType type) where T : ISessionEventHandler
        {
            Context.RegisterEventHandler<T>(type);
        }

        public void RegisterEventHandler<T>(List<Event.EventType> types) where T : ISessionEventHandler
        {
            foreach (Event.EventType type in types)
            {
                Context.RegisterEventHandler<T>(type);
            }
        }

        public void SendRequestAsync(Request request, CorrelationID id)
        {
            session.SendRequest(request, id);
        }

        public void Subscribe(List<Subscription> dSubscriptions)
        {
            session.Subscribe(dSubscriptions);
        }
    }
}