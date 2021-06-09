using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("tblEmployees");
            modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasColumnType("VARCHAR(100)");
            modelBuilder.Entity<Employee>().Property(p => p.LastName).HasColumnType("VARCHAR(100)");
            modelBuilder.Entity<Employee>().Property(p => p.Designation).HasColumnType("VARCHAR(100)");

            base.OnModelCreating(modelBuilder);
        }
    }
}