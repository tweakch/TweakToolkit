using System;
using System.Collections.Generic;

namespace TweakToolkit.MVVM.Gateway
{
    public interface IGateway : IDisposable
    {
        TEntity Create<TEntity>() where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        IEnumerable<TEntity> Read<TEntity>(Predicate<TEntity> filter) where TEntity : class;

        IEnumerable<TEntity> Read<TEntity>() where TEntity : class;

        void ResetDatabase(bool confirm);

        void Update<TEntity>(Predicate<TEntity> find, Action<TEntity> update) where TEntity : class;
    }
}