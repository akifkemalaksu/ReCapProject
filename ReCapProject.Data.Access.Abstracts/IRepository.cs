using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.Abstracts
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class, EntityBase<TKey>, new()
        where TKey : struct
    {
        void Add(TEntity entity);
        void Delete(TKey key);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(TKey key);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetList(int skip, int take, Expression<Func<TEntity, bool>> expression = null);
        void SaveChanges();
    }
}
