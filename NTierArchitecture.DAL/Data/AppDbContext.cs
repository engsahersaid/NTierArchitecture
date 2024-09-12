using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NTierArchitecture.DAL.Entities;
using System.Reflection;

namespace NTierArchitecture.DAL.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                //Auto Timestamp
                item.Entity.CreatedAt = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed some dummy data
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", Description = "Information Technology", CreatedAt = DateTime.Now },
            new Department { Id = 2, Name = "HR", Description = "Human Resources", CreatedAt = DateTime.Now });

            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Saher Said Fahd", DepartmentId = 1, Address = "Cairo", DateOfBirth = new DateTime(2000, 1, 1), CreatedAt = DateTime.Now },
            new Employee { Id = 2, Name = "Ahmed ", DepartmentId = 1, Address = "Cairo", DateOfBirth = new DateTime(1998, 1, 1), CreatedAt = DateTime.Now },
            new Employee { Id = 3, Name = "Ali", DepartmentId = 2, Address = "Cairo", DateOfBirth = new DateTime(2002, 1, 1), CreatedAt = DateTime.Now });
        }
    }
}