namespace NTierArchitecture.BLL.ViewModels
{
    public class DepartmentDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EmployeeListVM> Employees { get; set; }
    }
}