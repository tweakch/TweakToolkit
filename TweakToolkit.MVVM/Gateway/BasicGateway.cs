using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TweakToolkit.MVVM.Gateway.Exceptions;

namespace TweakToolkit.MVVM.Gateway
{
    public class BasicGateway<TDbContext> : IGateway where TDbContext : DbContext
    {
        public BasicGateway()
        {
            ActivateDbContext();
        }

        protected TDbContext Context { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
            Context = null;
        }

        public virtual TEntity Create<TEntity>() where TEntity : class
        {
            TEntity entity = null;

            try
            {
                DbSet<TEntity> dbSet = Context.Set<TEntity>();
                entity = dbSet.Create();
                dbSet.Add(entity);
                SaveChangesToDatabase();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("is not part of the model for the current context."))
                {
                    throw new UnknownEntityException("Unknown entity supplied to the gateway. Operation was canceled.",
                                                     ex);
                }
            }

            return entity;
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public virtual IEnumerable<TEntity> Read<TEntity>() where TEntity : class
        {
            var dbSet = Context.Set<TEntity>();
            return dbSet.AsEnumerable();
        }

        public virtual DbSet Read(Type entityType)
        {
            var dbSet = Context.Set(entityType);
            return dbSet;
        }

        public virtual IEnumerable<TEntity> Read<TEntity>(Predicate<TEntity> filter) where TEntity : class
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            IEnumerable<TEntity> asEnumerable = Read<TEntity>();
            IEnumerable<TEntity> resultSet = asEnumerable.Where(e => filter(e));
            return resultSet;
        }

        public void ResetDatabase(bool confirm = false)
        {
            if (!confirm) throw new UnconfirmedDatabaseResetException();
            Context.Database.Delete();
            Context.SaveChanges();
            Context.Database.Create();
            SaveChangesToDatabase();
        }

        public virtual void Update<TEntity>(Predicate<TEntity> find, Action<TEntity> update) where TEntity : class
        {
            DbSet<TEntity> dbSet = Context.Set<TEntity>();
            IEnumerable<TEntity> asEnumerable = dbSet.AsEnumerable();
            TEntity currentEntity = asEnumerable.First(e => find(e));
            update(currentEntity);
            SaveChangesToDatabase();
        }

        protected virtual void SaveChangesToDatabase()
        {
            int saveChanges = Context.SaveChanges();
            if (saveChanges != 0)
            {
            }
        }

        private void ActivateDbContext()
        {
            Context = Activator.CreateInstance<TDbContext>();
        }
    }
}