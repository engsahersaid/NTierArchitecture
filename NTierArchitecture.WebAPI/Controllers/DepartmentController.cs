using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.BLL.Services.Interfaces;
using NTierArchitecture.BLL.ViewModels;

namespace NTierArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public Task<IEnumerable<DepartmentListVM>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _departmentService.GetAllAsync(cancellationToken);
        }

        [HttpGet]
        public Task<DepartmentDetailsVM> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _departmentService.GetByIdAsync(id, cancellationToken);
        }
    }
}