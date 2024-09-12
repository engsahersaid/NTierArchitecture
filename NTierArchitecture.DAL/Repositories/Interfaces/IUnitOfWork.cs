using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }

        IRepository<T> Repository<T>() where T : BaseEntity, new();

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}