using Entities.WebAPI;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.WebAPI;
using Services.WebAPI.Helpers;

namespace Services.WebAPI;

public class EmployeeService : IEmployeeService
{
   //Injection DataBase through DI
    private readonly ApplicationDBContext _dBContext;

    public EmployeeService(ApplicationDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    //Services
    public async Task<ServiceResults<EmployeeResponse>> AddEmployees(EmployeeAddRequest employeeAddRequest)
    {
        if(employeeAddRequest == null)
        {
            throw new ArgumentNullException(nameof(employeeAddRequest));
        }

        //handling the errors by Consuming the ValidationHelper method
        var errors = ValidationHelpers.Validate(employeeAddRequest);

        if(errors.Count > 0)
        {
            return new ServiceResults<EmployeeResponse>()
            {
                Success = false,
                errors = errors
            };
        }

        //Check for Duplicate Email or existing user
        var existingUser = await _dBContext.employees.FirstOrDefaultAsync(e => e.Email == employeeAddRequest.Email);

        if(existingUser != null)
        {
            return new ServiceResults<EmployeeResponse>()
            {
                Success = false,
                errors = new List<string>()
                {
                    "User Exists with Same Email-ID"
                }
            };
        }


        //converting EMployeeAddRequest to Employee Entity
        var employee = employeeAddRequest.ToEmployee();

        //generate new GUID & CreatedTime and UpdateAt = null,
        employee.EmployeeId = Guid.NewGuid();
        employee.CreatedAt = DateTime.UtcNow;
        employee.UpdatedAt = null;

        //adding to DB
        _dBContext.employees.Add(employee);
        await _dBContext.SaveChangesAsync();

        //Returning as Response
        return new ServiceResults<EmployeeResponse>()
        {
            Success = true,
            Data = employee.ToEmployeeResponse()
        };


    }

    public async Task<bool> DeleteEmployees(Guid? employeeID)
    {
        if(employeeID == null)
        {
            throw new ArgumentNullException(nameof(employeeID));
        }

        var employee = await _dBContext.employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeID.Value);

        if(employee == null)
        {
            return false;
        }

        _dBContext.employees.Remove(employee);

        await _dBContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<EmployeeResponse>> GetAllEmployees()
    {
        //add employees to list
        var employees = await _dBContext.employees.ToListAsync();

        //convert all employees to EmployeeResponse
        return employees.Select(e => e.ToEmployeeResponse()).ToList();
    }

    public async Task<EmployeeResponse> GetEmployeesByEmployeeID(Guid? employeeID)
    {
      
        var employee = await _dBContext.employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeID);

        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employeeID));
        }

        return employee.ToEmployeeResponse();

    }

    public async Task<EmployeeResponse?> UpdateEmployees(Guid employeeId, EmployeeAddRequest request) 
    { 
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var matchingEmployee = await _dBContext.employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        if (matchingEmployee == null)
        {
            return null;
        }

        matchingEmployee.FirstName = request.FirstName;
        matchingEmployee.LastName = request.LastName;
        matchingEmployee.Email = request.Email;
        matchingEmployee.Phone = request.Phone;
        matchingEmployee.DateOfBirth = request.DateOfBirth;
        matchingEmployee.DateOfJoining = request.DateOfJoining;
        matchingEmployee.Salary = request.Salary;
        matchingEmployee.DepartmentId = request.DepartmentId;
        matchingEmployee.IsActive = request.IsActive;

        matchingEmployee.UpdatedAt = DateTime.UtcNow;

        await _dBContext.SaveChangesAsync();

        return matchingEmployee.ToEmployeeResponse();
    }
}
