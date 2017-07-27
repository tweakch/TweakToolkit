using System;

namespace TweakToolkit.EntityFramework.Strategies
{
    public abstract class GatewayStrategy : IGatewayStrategy
    {
        public object Execute(object message)
        {
            OnExecuting(new ExecutingEventArgs(message));
            var result = DoWork(message);
            OnExecuted(new ExecutedEventArgs(message, result));
            return result;
        }

        public event EventHandler<ExecutingEventArgs> Executing;

        public event EventHandler<ExecutedEventArgs> Executed;

        protected abstract object DoWork(object message);

        protected virtual void OnExecuting(ExecutingEventArgs e)
        {
            EventHandler<ExecutingEventArgs> handler = Executing;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnExecuted(ExecutedEventArgs e)
        {
            EventHandler<ExecutedEventArgs> handler = Executed;
            if (handler != null) handler(this, e);
        }
    }
}