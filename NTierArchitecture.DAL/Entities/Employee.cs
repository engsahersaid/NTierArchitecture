namespace NTierArchitecture.DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}