using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Core.Business
{
    public interface IBusinessEngine<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        TEntity GetById(TKey key);
        TEntity GetByExpression(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> expression = null);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
