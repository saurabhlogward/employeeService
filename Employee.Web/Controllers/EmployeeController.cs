using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Web.Dto;
using Employee.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET api/employee
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public EmployeeDto Get(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        // POST api/employee
        [HttpPost]
        public EmployeeDto Post([FromBody]EmployeeDto value)
        {
            return _employeeService.Add(value);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _employeeService.Delete(id);
        }
    }
}
