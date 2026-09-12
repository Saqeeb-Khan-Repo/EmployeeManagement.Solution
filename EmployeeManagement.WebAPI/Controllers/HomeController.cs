using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.WebAPI;

namespace EmployeeManagement.WebAPI.Controllers;

/// <summary>
/// request => HomeController => services => database => response
/// </summary>
[ApiController]
[Route("api/employees")]

public class HomeController : ControllerBase
{
  
    private readonly IEmployeeService _employeeService;
    public HomeController(IEmployeeService employee)
    {
        _employeeService = employee;
    }
    /// <summary>
    /// This method Returns All Employees From the "Employees" DB Table
    /// </summary>
    /// <returns></returns>

    [HttpGet]
    public async Task<IActionResult> GetAllEmployee()
    {
        var employees = await _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{employeeID}")]
    public async Task<IActionResult> GetEmployeeByEmployeeID(Guid employeeID)
    {
        var employee = await _employeeService.GetEmployeesByEmployeeID(employeeID);

        if (employee == null )
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeAddRequest employeeRequest)
    {
        var employee = await _employeeService.AddEmployees(employeeRequest);

        //consuming ServiceResult Response 
        if (!employee.Success)
        {
            return BadRequest(new
            {
                message = "Validation Failed",
                error = employee.errors
            });
        }

        return CreatedAtAction(
            nameof(GetEmployeeByEmployeeID),
            new { employeeID = employee.Data!.EmployeeId},
            employee.Data
        );

    }


    [HttpPut("{employeeID:guid}")]
    public async Task<IActionResult> UpdateEmployee(
     Guid employeeID,
     EmployeeAddRequest request)
    {
        var updatedEmployee =
            await _employeeService.UpdateEmployees(employeeID, request);

        if (updatedEmployee == null)
        {
            return NotFound();
        }

        return Ok(updatedEmployee);
    }


    [HttpDelete("{employeeID}")]
    public async Task<IActionResult> DeleteEmployee(Guid employeeID)
    {
        var employee = await _employeeService.DeleteEmployees(employeeID);
        //if(employee == null)
        //{
        //    return NotFound();
        //}

     
        return Content($"Employee Deleted Successfully");

    }
}
