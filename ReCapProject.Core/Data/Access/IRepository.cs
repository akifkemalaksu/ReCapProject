using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Core.Data.Access
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct
    {
        TEntity Add(TEntity entity);
        void Delete(TKey key);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Get(TKey key);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetList(int skip, int take, Expression<Func<TEntity, bool>> expression = null);
        void SaveChanges();
    }
}
