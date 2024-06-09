using System.Linq.Expressions;

namespace HXT.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>>? expression);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
    }
}
