using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Core.Business
{
    public class BusinessEngineBase<TEntity, TRepository, TKey> : IBusinessEngine<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TRepository : class, IRepository<TEntity, TKey>
        where TKey : struct
    {
        protected readonly TRepository _repository;

        public BusinessEngineBase(TRepository repository)
        {
            _repository = repository;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _repository.SaveChanges();
        }

        public List<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> expression = null)
        {
            return _repository.GetList(skip, take, expression);
        }

        public TEntity GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Get(expression);
        }

        public TEntity GetById(TKey key)
        {
            return _repository.Get(key);
        }

        public TEntity Insert(TEntity entity)
        {
            entity = _repository.Add(entity);
            _repository.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity = _repository.Update(entity);
            _repository.SaveChanges();
            return entity;
        }
    }
}
