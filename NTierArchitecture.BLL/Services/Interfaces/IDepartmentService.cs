using NTierArchitecture.BLL.ViewModels;

namespace NTierArchitecture.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentListVM>> GetAllAsync(CancellationToken cancellationToken);

        Task<DepartmentDetailsVM> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}