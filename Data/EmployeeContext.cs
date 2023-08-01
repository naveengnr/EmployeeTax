using   Microsoft.EntityFrameworkCore;
using EmployeeTax.Models;

namespace EmployeeTax.Data
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Employees> ? Employees {get;set;}
        public DbSet<Details> ? Details {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>()
            .HasMany(e => e.details)
            .WithOne(d => d.Employees)
            .HasForeignKey(d => d.EmployeeId);
    }
    }
}