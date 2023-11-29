using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ostim.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Companies { get; set; }
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=employee;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Company A", Zipcode = "06450", City = "Ankara", Country = "Turkiye" },
                new Company { Id = 2, Name = "Company B", Zipcode = "06450", City = "Istanbul", Country = "Turkiye" },
                new Company { Id = 3, Name = "Company C", Zipcode = "06450", City = "Ankara", Country = "Turkiye" },
                new Company { Id = 4, Name = "Company D", Zipcode = "06450", City = "Ankara D", Country = "Turkiye" },
                new Company { Id = 5, Name = "Company E", Zipcode = "06450", City = "Istanbul", Country = "Turkiye" }
            );

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Surname).IsRequired();
                entity.Property(c => c.Position).IsRequired();
            });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Test", Surname = "test", Position = "Default Position" }
            );

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.SalaryInfo)
                .WithOne(si => si.Employee)
                .HasForeignKey<SalaryInfo>(si => si.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
