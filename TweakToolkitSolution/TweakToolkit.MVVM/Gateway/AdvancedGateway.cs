using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace TweakToolkit.MVVM.Gateway
{
    public class AdvancedGateway<TDbContext> : BasicGateway<TDbContext> where TDbContext : DbContext
    {
        public TEntity ReadById<TEntity>(object id) where TEntity : class
        {
            IEnumerable<TEntity> enumerable = Read<TEntity>(entity => HasIdPredicate(entity, id));
            return enumerable.Single();
        }

        public void UpdateById<TEntity>(object id, Action<TEntity> update) where TEntity : class
        {
            Update(entity => HasIdPredicate(entity, id), update);
        }

        private static object GetPropertyValue<TEntity>(TEntity entity, string propertyName, Type propertyType)
            where TEntity : class
        {
            PropertyInfo propertyInfo = typeof (TEntity).GetProperty(propertyName, propertyType);
            return propertyInfo.GetValue(entity, null);
        }

        private static bool HasIdPredicate<TEntity>(TEntity entity, object id) where TEntity : class
        {
            const string propertyName = "Id";
            Type propertyType = id.GetType();
            return GetPropertyValue(entity, propertyName, propertyType).Equals(id);
        }
    }
}