using NTierArchitecture.BLL.ViewModels;

namespace NTierArchitecture.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeListVM>> GetAllAsync(CancellationToken cancellationToken);

        Task<EmployeeDetailsVM> GetByIdAsync(int employeeId, CancellationToken cancellationToken);

        Task<EmployeeDetailsVM> CreateAsync(AddEmployeeVM employeeViewModel, CancellationToken cancellationToken);

        Task<EmployeeDetailsVM> UpdateAsync(int employeeId, AddEmployeeVM employeeViewModel, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int employeeId, CancellationToken cancellationToken);
    }
}