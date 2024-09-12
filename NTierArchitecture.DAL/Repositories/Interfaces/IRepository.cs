using NTierArchitecture.DAL.Entities;
using System.Linq.Expressions;

namespace NTierArchitecture.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T? GetById(int id);

        Task<T?> GetByIdAsync(int id);

        IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        Task<List<T>> FindListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default);

        Task<List<T>> FindAllAsync(CancellationToken cancellationToken);

        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}