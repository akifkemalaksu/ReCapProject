using ReCapProject.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ReCapProject.Core.DataAccess
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

        ICollection<TEntity> GetList(Expression<Func<TEntity, bool>> expression);

        void SaveChanges();
    }
}