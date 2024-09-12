namespace NTierArchitecture.BLL.ViewModels
{
    public class EmployeeDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentListVM Department { get; set; }
    }
}