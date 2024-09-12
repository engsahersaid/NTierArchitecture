using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.DAL.Config
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.Name).IsRequired();
            builder.HasIndex(d => d.Name).IsUnique();
        }
    }
}