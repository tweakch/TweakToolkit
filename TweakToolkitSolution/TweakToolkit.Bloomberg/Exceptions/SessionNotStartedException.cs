using System;

namespace TweakToolkit.Bloomberg.Exceptions
{
    public class SessionNotStartedException : Exception
    {
        public SessionNotStartedException()
            : base("Session could not be started")
        {
        }
    }
}