using System.Collections.Generic;
using Bloomberglp.Blpapi;
using TweakToolkit.Bloomberg.Exceptions;

namespace TweakToolkit.Bloomberg.New
{
    public abstract class SessionBase
    {
        private const string ServerHost = "localhost";
        private const int ServerPort = 8194;

        readonly SessionOptions _sessionOptions = new SessionOptions();
        protected Session Session;
        
        protected SessionBase()
        {
            _sessionOptions.ServerHost = ServerHost;
            _sessionOptions.ServerPort = ServerPort;
            Session = new Session(_sessionOptions);
        }

        protected virtual bool OpenService(string blpMktdata)
        {
            return Session.OpenService(blpMktdata);
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

        public virtual CorrelationID GenerateToken()
        {
            return Session.GenerateToken();
        }

        public virtual Identity CreateIdentity()
        {
            return Session.CreateIdentity();
        }

        public virtual void Cancel(IList<CorrelationID> correlators)
        {
            Session.Cancel(correlators);
        }

        public virtual void Cancel(CorrelationID correlationId)
        {
            Session.Cancel(correlationId);
        }
    }
}