using AutoMapper;
using NTierArchitecture.BLL.Services.Interfaces;
using NTierArchitecture.BLL.ViewModels;
using NTierArchitecture.DAL.Entities;
using NTierArchitecture.DAL.Repositories.Interfaces;

namespace NTierArchitecture.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DepartmentListVM>> GetAllAsync(CancellationToken cancellationToken)
        {
            var departments = await _unitOfWork.Repository<Department>().FindAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<DepartmentListVM>>(departments);
        }

        public async Task<DepartmentDetailsVM> GetByIdAsync(int departmentId, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.Repository<Department>().SingleOrDefaultAsync(d => d.Id == departmentId, "Employees");
            return _mapper.Map<DepartmentDetailsVM>(department);
        }
    }
}