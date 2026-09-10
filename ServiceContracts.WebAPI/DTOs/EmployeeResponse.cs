using Entities.WebAPI;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace ServiceContracts;


public class EmployeeResponse
{
    public Guid EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}


public static class EmployeeExtensions
{
    public static EmployeeResponse ToEmployeeResponse(
        this Employee employee)
    {
        return new EmployeeResponse
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone,
            DateOfBirth = employee.DateOfBirth,
            DateOfJoining = employee.DateOfJoining,
            Salary = employee.Salary,
            DepartmentId = employee.DepartmentId,
            IsActive = employee.IsActive,
            CreatedAt = employee.CreatedAt,
            UpdatedAt = employee.UpdatedAt
        };
    }
}