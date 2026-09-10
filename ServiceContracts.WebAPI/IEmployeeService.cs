
namespace ServiceContracts.WebAPI
{
    public interface IEmployeeService
    {

        public Task<List<EmployeeResponse>> GetAllEmployees();

        public Task<EmployeeResponse> GetEmployeesByEmployeeID(Guid? employeeID);

        public Task<ServiceResults<EmployeeResponse>> AddEmployees(EmployeeAddRequest employeeAddRequest);

        public Task<EmployeeResponse?> UpdateEmployees(Guid employeeID,EmployeeAddRequest employeeAddRequest);

        public  Task<bool> DeleteEmployees(Guid? employeeID);

    }
}
