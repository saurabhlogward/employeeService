using System.Collections.Generic;
using Employee.Web.Dto;

namespace Employee.Web.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int employeeId);
        EmployeeDto Add(EmployeeDto employee);
        bool Delete(int employeeId);
    }
}
