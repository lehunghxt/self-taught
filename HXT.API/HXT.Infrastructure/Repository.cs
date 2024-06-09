using HXT.Domain.Base;
using HXT.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HXT.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Add(T entity)
        {
            if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedTime = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>>? expression)
        {
            if (expression == null) return DbSet;
            return DbSet.Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).LastSavedTime = DateTime.UtcNow;
            }
            DbSet.Update(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
