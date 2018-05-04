using System.Collections.Generic;
using Employee.Web.Dto;
using Employee.Web.Repository;

namespace Employee.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public EmployeeDto GetEmployee(int employeeId)
        {
            return _repository.GetEmployee(employeeId);
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _repository.GetEmployees();
        }

        public EmployeeDto Add(EmployeeDto employee)
        {
            return _repository.Add(employee);
        }

        public bool Delete(int id)
        {
           return _repository.Delete(id);
        }
    }

}