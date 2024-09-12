using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.BLL.Services.Interfaces;
using NTierArchitecture.BLL.ViewModels;

namespace NTierArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public Task<IEnumerable<EmployeeListVM>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _employeeService.GetAllAsync(cancellationToken);
        }

        [HttpPost]
        public Task<EmployeeDetailsVM> PostAsync([FromBody] AddEmployeeVM model, CancellationToken cancellationToken)
        {
            return _employeeService.CreateAsync(model, cancellationToken);
        }

        [HttpGet]
        public Task<EmployeeDetailsVM> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _employeeService.GetByIdAsync(id, cancellationToken);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return _employeeService.DeleteAsync(id, cancellationToken);
        }

        [HttpPut]
        public Task<EmployeeDetailsVM> Update(int id, [FromBody] AddEmployeeVM model, CancellationToken cancellationToken)
        {
            return _employeeService.UpdateAsync(id, model, cancellationToken);
        }
    }
}