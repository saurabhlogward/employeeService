using System.Collections.Generic;
using Employee.Web.Dto;

namespace Employee.Web.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int employeeId);
        EmployeeDto Add(EmployeeDto employee);
        bool Delete(int id);
    }
}