using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;
using EventHandler = Bloomberglp.Blpapi.EventHandler;

namespace TweakToolkit.Bloomberg.New
{
    public enum SessionState
    {
        Connecting, Connected, Disconnecting, Disconnected
    }

    public abstract class SessionBase
    {
        public ASessionBehaviourBase Behaviour { get; set; }
        protected Session Session;
        protected Service Service;
        private const string ServerHost = "localhost";
        private const int ServerPort = 8194;
        private readonly SessionOptions sessionOptions = new SessionOptions();

        protected SessionBase(ASessionBehaviourBase behaviour)
        {
            State = SessionState.Disconnected;
            Behaviour = behaviour;
            Behaviour.ServiceOpened += BehaviourOnServiceOpened;
            sessionOptions.ServerHost = ServerHost;
            sessionOptions.ServerPort = ServerPort;
            Session = new Session(sessionOptions, Behaviour.Execute);
        }

        private void BehaviourOnServiceOpened(object sender, ServiceOpenedEventArgs serviceOpenedEventArgs)
        {
            Service = serviceOpenedEventArgs.Service;
            if (Service != null) { State = SessionState.Connected; }
        }

        public virtual void Cancel(IList<CorrelationID> correlators)
        {
            Session.Cancel(correlators);
        }

        public virtual void Cancel(CorrelationID correlationId)
        {
            Session.Cancel(correlationId);
        }

        public virtual CorrelationID GenerateToken()
        {
            return Session.GenerateToken();
        }

        public void SetEventHandler(Event.EventType type, Bloomberglp.Blpapi.EventHandler handler)
        {
            Session.SetEventHandler(handler, type);
        }

        public virtual void Start()
        {
            State = SessionState.Connecting;
            Session.StartAsync();
        }

        public virtual void Stop()
        {
            State = SessionState.Disconnecting;
            Session.Stop();
            State = SessionState.Disconnected;
        }

        protected virtual bool OpenService(string service)
        {
            return Session.OpenService(service);
        }

        public SessionState State { get; set; }
    }
}