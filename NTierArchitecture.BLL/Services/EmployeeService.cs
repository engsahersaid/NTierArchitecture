using AutoMapper;
using FluentValidation;
using NTierArchitecture.BLL.Services.Interfaces;
using NTierArchitecture.BLL.ViewModels;
using NTierArchitecture.DAL.Entities;
using NTierArchitecture.DAL.Repositories.Interfaces;

namespace NTierArchitecture.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<Employee> _validator;

        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Employee> validator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<EmployeeDetailsVM> CreateAsync(AddEmployeeVM model, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(model);
            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors[0].ErrorMessage);

            _unitOfWork.Employee.Add(employee);
            var result = await _unitOfWork.CommitAsync(cancellationToken);
            if (result > 0)
                return _mapper.Map<EmployeeDetailsVM>(employee);
            return new EmployeeDetailsVM();
        }

        public async Task<bool> DeleteAsync(int employeeId, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(employeeId);
            if (employee == null)
                throw new Exception("Employee not found");

            _unitOfWork.Employee.Delete(employee);
            return await _unitOfWork.CommitAsync(cancellationToken) > 0;
        }

        public async Task<IEnumerable<EmployeeListVM>> GetAllAsync(CancellationToken cancellationToken)
        {
            var employees = await _unitOfWork.Employee.FindAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<EmployeeListVM>>(employees);
        }

        public async Task<EmployeeDetailsVM> GetByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employee.SingleOrDefaultAsync(e => e.Id == employeeId, "Department");
            return _mapper.Map<EmployeeDetailsVM>(employee);
        }

        public async Task<EmployeeDetailsVM> UpdateAsync(int employeeId, AddEmployeeVM model, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(employeeId);
            if (employee == null)
                throw new Exception("Employee not found");

            employee = _mapper.Map<Employee>(model);

            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors[0].ErrorMessage);

            _unitOfWork.Employee.Update(employee);
            var result = await _unitOfWork.CommitAsync(cancellationToken);
            if (result > 0)
                return _mapper.Map<EmployeeDetailsVM>(employee);
            return new EmployeeDetailsVM();
        }
    }
}