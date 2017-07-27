using System;
using System.Threading.Tasks;
using TweakToolkit.EntityFramework.Strategies;

namespace TweakToolkit.EntityFramework
{
    public class SimpleGatewayImpl : IDisposable
    {
        private TweakTestDataEntities _entities;

        public SimpleGatewayImpl()
        {
            _entities = new TweakTestDataEntities();
        }

        public void Dispose()
        {
            _entities = null;
        }

        public event EventHandler<GatewayErrorEventArgs> ErrorOccurred;

        protected virtual void OnErrorOccurred(GatewayErrorEventArgs e)
        {
            EventHandler<GatewayErrorEventArgs> handler = ErrorOccurred;
            if (handler != null) handler(this, e);
        }

        #region Create Logic

        public event EventHandler<CreatingEventArgs> Creating;

        protected virtual void OnCreating(CreatingEventArgs e)
        {
            EventHandler<CreatingEventArgs> handler = Creating;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<CreatedEventArgs> Created;

        protected virtual void OnCreated(CreatedEventArgs e)
        {
            EventHandler<CreatedEventArgs> handler = Created;
            if (handler != null) handler(this, e);
        }

        public Task<object> CreateAsync(CreateMessage message)
        {
            return Task.Factory.StartNew<object>(Create, message);
        }

        public object Create(object message)
        {
            var createMessage = message as CreateMessage;
            object result = null;

            if (createMessage != null)
            {
                var strategy = CreationStrategies.Resolve(_entities, createMessage);
                if (strategy != null)
                {
                    strategy.Executing +=
                        (sender, args) => OnCreating(new CreatingEventArgs(args.Message as CreateMessage));
                    strategy.Executed +=
                        (sender, args) => OnCreated(new CreatedEventArgs(args.Message as CreateMessage, args.Result));
                    result = strategy.Execute(message);
                }
                else
                {
                    OnErrorOccurred(new StrategyErrorEventArgs(new NullReferenceException("strategy")));
                }
            }

            return result;
        }

        #endregion Create Logic
    }
}