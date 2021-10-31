using Microsoft.EntityFrameworkCore;
using ReCapProject.Data.Access.Abstracts;
using ReCapProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Data.Access.EntityFramework.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TEntity : class, EntityBase<TKey>, new()
        where TKey : struct
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #region IRepository

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TKey key)
        {
            var entity = Get(key);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
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

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #endregion

        #region IDisposable

        ~RepositoryBase()
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
