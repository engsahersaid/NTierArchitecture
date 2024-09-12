using NTierArchitecture.DAL.Data;
using NTierArchitecture.DAL.Entities;
using NTierArchitecture.DAL.Repositories.Interfaces;

namespace NTierArchitecture.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _dbContext;
        private bool _disposed;

        private IEmployeeRepository _employee;

        public UnitOfWork(IAppDbContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();
            _disposed = true;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity, new()
        {
            return new Repository<T>(_dbContext);
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_dbContext);
                }
                return _employee;
            }
        }
    }
}