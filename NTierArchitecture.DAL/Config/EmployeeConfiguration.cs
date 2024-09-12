using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.DAL.Config
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).IsRequired();

            builder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}