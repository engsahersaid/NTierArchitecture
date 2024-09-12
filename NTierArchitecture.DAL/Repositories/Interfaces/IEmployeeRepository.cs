using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken);
    }
}