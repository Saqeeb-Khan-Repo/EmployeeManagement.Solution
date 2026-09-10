using Microsoft.EntityFrameworkCore;

namespace Entities.WebAPI;

public class ApplicationDBContext : DbContext
{
   //Constructor
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<Employee> employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().ToTable("Employees");

        modelBuilder.Entity<Employee>().HasData(
      new Employee
      {
          EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
          FirstName = "Saqeeb",
          LastName = "Khan",
          Email = "saqeeb.khan@example.com",
          Phone = "+91-9876543210",
          DateOfBirth = new DateTime(2002, 5, 15),
          DateOfJoining = new DateTime(2025, 7, 1),
          Salary = 55000.00m,
          DepartmentId = 1,
          IsActive = true,
          CreatedAt = new DateTime(2025, 7, 1, 9, 0, 0),
          UpdatedAt = null
      },

      new Employee
      {
          EmployeeId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
          FirstName = "Ahmed",
          LastName = "Ali",
          Email = "ahmed.ali@example.com",
          Phone = "+91-9876543211",
          DateOfBirth = new DateTime(2001, 8, 20),
          DateOfJoining = new DateTime(2024, 10, 15),
          Salary = 65000.00m,
          DepartmentId = 2,
          IsActive = true,
          CreatedAt = new DateTime(2024, 10, 15, 9, 0, 0),
          UpdatedAt = null
      },

      new Employee
      {
          EmployeeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
          FirstName = "Fatima",
          LastName = "Shaikh",
          Email = "fatima.shaikh@example.com",
          Phone = "+91-9876543212",
          DateOfBirth = new DateTime(2000, 12, 10),
          DateOfJoining = new DateTime(2023, 3, 20),
          Salary = 72000.00m,
          DepartmentId = 1,
          IsActive = true,
          CreatedAt = new DateTime(2023, 3, 20, 9, 0, 0),
          UpdatedAt = null
      }
  );




    }
}
