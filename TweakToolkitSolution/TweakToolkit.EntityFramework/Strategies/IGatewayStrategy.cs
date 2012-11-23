using System;

namespace TweakToolkit.EntityFramework.Strategies
{
    public interface IGatewayStrategy
    {
        object Execute(object message);

        event EventHandler<ExecutingEventArgs> Executing;

        event EventHandler<ExecutedEventArgs> Executed;
    }
}