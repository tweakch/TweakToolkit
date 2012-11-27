using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Exceptions;

namespace TweakToolkit.Bloomberg.New
{
    public abstract class SessionBase
    {
        protected Session Session;
        private const string ServerHost = "localhost";
        private const int ServerPort = 8194;
        private readonly SessionOptions sessionOptions = new SessionOptions();

        protected SessionBase(ASessionEventHandler handler)
        {
            sessionOptions.ServerHost = ServerHost;
            sessionOptions.ServerPort = ServerPort;
            Session = new Session(sessionOptions);
            handler.RegisterSession(this);
        }

        public virtual void Cancel(IList<CorrelationID> correlators)
        {
            Session.Cancel(correlators);
        }

        public virtual void Cancel(CorrelationID correlationId)
        {
            Session.Cancel(correlationId);
        }

        public virtual Identity CreateIdentity()
        {
            return Session.CreateIdentity();
        }

        public virtual CorrelationID GenerateToken()
        {
            return Session.GenerateToken();
        }

        public void SetEventHandler(SimpleEventHandler eventHandler, Event.EventType eventType)
        {
            Session.SetEventHandler((eventObject, session) => eventHandler(eventObject), eventType);
        }

        public virtual void Start()
        {
            if (!Session.Start())
            {
                throw new SessionNotStartedException();
            }
        }

        public virtual void Stop()
        {
            Session.Stop();
        }

        protected virtual bool OpenService(string blpMktdata)
        {
            return Session.OpenService(blpMktdata);
        }
    }
}