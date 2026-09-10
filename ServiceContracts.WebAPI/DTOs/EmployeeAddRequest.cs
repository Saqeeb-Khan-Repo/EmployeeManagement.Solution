using Entities.WebAPI;

namespace ServiceContracts;

public class EmployeeAddRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfJoining { get; set; }
    public decimal? Salary { get; set; }
    public int? DepartmentId { get; set; }
    public bool IsActive { get; set; }

    public Employee ToEmployee()
    {
        return new Employee
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            DateOfBirth = DateOfBirth,
            DateOfJoining = DateOfJoining,
            Salary = Salary,
            DepartmentId = DepartmentId,
            IsActive = IsActive
        };
    }
}
