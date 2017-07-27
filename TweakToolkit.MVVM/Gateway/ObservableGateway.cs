using System;
using System.Collections.Generic;
using System.Data.Entity;
using TweakToolkit.MVVM.Gateway.EventArgs;

namespace TweakToolkit.MVVM.Gateway
{
    public class ObservableGateway<TDbContext> : BasicGateway<TDbContext> where TDbContext : DbContext
    {
        #region Events

        public event EventHandler<CreateCompletedEventArgs> CreateCompleted;

        public event EventHandler<CreatingEventArgs> Creating;

        public event EventHandler<DeleteCompletedEventArgs> DeleteCompleted;

        public event EventHandler<DeletingEventArgs> Deleting;

        public event EventHandler<ReadCompletedEventArgs> ReadCompleted;

        public event EventHandler<ReadingEventArgs> Reading;

        public event EventHandler<SaveCompletedEventArgs> SaveCompleted;

        public event EventHandler<SavingEventArgs> Saving;

        public event EventHandler<UpdateCompletedEventArgs> UpdateCompleted;

        public event EventHandler<UpdatingEventArgs> Updating;

        protected virtual void OnCreateCompleted(CreateCompletedEventArgs e)
        {
            EventHandler<CreateCompletedEventArgs> handler = CreateCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCreating(CreatingEventArgs e)
        {
            EventHandler<CreatingEventArgs> handler = Creating;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDeleteCompleted(DeleteCompletedEventArgs e)
        {
            EventHandler<DeleteCompletedEventArgs> handler = DeleteCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnDeleting(DeletingEventArgs e)
        {
            EventHandler<DeletingEventArgs> handler = Deleting;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnReadCompleted(ReadCompletedEventArgs e)
        {
            EventHandler<ReadCompletedEventArgs> handler = ReadCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnReading(ReadingEventArgs e)
        {
            EventHandler<ReadingEventArgs> handler = Reading;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSaveCompleted(SaveCompletedEventArgs e)
        {
            EventHandler<SaveCompletedEventArgs> handler = SaveCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSaving(SavingEventArgs e)
        {
            EventHandler<SavingEventArgs> handler = Saving;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnUpdateCompleted(UpdateCompletedEventArgs e)
        {
            EventHandler<UpdateCompletedEventArgs> handler = UpdateCompleted;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnUpdating(UpdatingEventArgs e)
        {
            EventHandler<UpdatingEventArgs> handler = Updating;
            if (handler != null) handler(this, e);
        }

        #endregion Events

        public override TEntity Create<TEntity>()
        {
            OnCreating(new CreatingEventArgs());
            var entity = base.Create<TEntity>();
            OnCreateCompleted(new CreateCompletedEventArgs());
            return entity;
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            OnDeleting(new DeletingEventArgs());
            base.Delete(entity);
            OnDeleteCompleted(new DeleteCompletedEventArgs());
        }

        public override IEnumerable<TEntity> Read<TEntity>()
        {
            OnReading(new ReadingEventArgs());
            IEnumerable<TEntity> enumerable = base.Read<TEntity>();
            OnReadCompleted(new ReadCompletedEventArgs());
            return enumerable;
        }

        public override IEnumerable<TEntity> Read<TEntity>(Predicate<TEntity> filter)
        {
            OnReading(new ReadingEventArgs());
            IEnumerable<TEntity> enumerable = base.Read(filter);
            OnReadCompleted(new ReadCompletedEventArgs());
            return enumerable;
        }

        public override void Update<TEntity>(Predicate<TEntity> find, Action<TEntity> update)
        {
            OnUpdating(new UpdatingEventArgs());
            base.Update(find, update);
            OnUpdateCompleted(new UpdateCompletedEventArgs());
        }

        protected override void SaveChangesToDatabase()
        {
            OnSaving(new SavingEventArgs());
            base.SaveChangesToDatabase();
            OnSaveCompleted(new SaveCompletedEventArgs());
        }
    }
}