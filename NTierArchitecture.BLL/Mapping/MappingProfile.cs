using AutoMapper;
using NTierArchitecture.BLL.ViewModels;
using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDetailsVM>();
            CreateMap<Employee, EmployeeListVM>();
            CreateMap<AddEmployeeVM, Employee>();

            CreateMap<Department, DepartmentDetailsVM>();
            CreateMap<Department, DepartmentListVM>();
        }
    }
}