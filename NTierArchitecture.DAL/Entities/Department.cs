namespace NTierArchitecture.DAL.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}