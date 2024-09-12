using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DAL.Data;
using NTierArchitecture.DAL.Entities;
using NTierArchitecture.DAL.Repositories.Interfaces;

namespace NTierArchitecture.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private IAppDbContext _dbContext;

        public EmployeeRepository(IAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Employee>> GetByDepartmentAsync(int departmentId, CancellationToken cancellationToken)
        {
            return _dbContext.Set<Employee>().Where(x => x.DepartmentId == departmentId).Include(x => x.Department).ToListAsync(cancellationToken);
        }
    }
}