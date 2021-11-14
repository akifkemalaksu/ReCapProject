using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.Data.Access;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class EFRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TContext : DbContext, new()
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct
    {
        protected readonly TContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        protected EFRepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #region IRepository

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(TKey key)
        {
            var entity = Get(key);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Get(TKey key)
        {
            return _dbSet.Find(key);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).FirstOrDefault();
        }

        public List<TEntity> GetList(int skip, int take, Expression<Func<TEntity, bool>> expression = null)
        {
            return expression is null ?
                _dbSet.Skip(skip).Take(take).ToList() :
                _dbSet.Where(expression).Skip(skip).Take(take).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #endregion

        #region IDisposable

        ~EFRepositoryBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
