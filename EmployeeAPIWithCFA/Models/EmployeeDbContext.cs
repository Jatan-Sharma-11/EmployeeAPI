using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIWithCFA.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(DbModelbuilder modelBuilder)
        //{
        //    modelBuilder.Entity<yourEntity>().MapToStoredProcedures();
        //}
    }
}
