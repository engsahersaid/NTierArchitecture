using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DAL.Data;
using NTierArchitecture.DAL.Entities;
using NTierArchitecture.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace NTierArchitecture.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IAppDbContext _dbContext;

        internal Repository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            var query = _dbContext.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public Task<List<T>> FindListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
        {
            var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
            return orderBy != null
                ? orderBy(query).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
        }

        public Task<List<T>> FindAllAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            query = includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.SingleOrDefaultAsync(expression);
        }

        public T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}