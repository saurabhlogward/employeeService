using System;
using System.Collections.Generic;
using Employee.Web.Dto;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Employee.Web.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IConfiguration _configuration { get; }

        private string _connectionString;
        private NpgsqlConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["Data:PostgreConnection:ConnectionString"];
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            using (var connection = Connection)
            {
                connection.Open();

                var command = new NpgsqlCommand("SELECT * FROM Employee", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employeeDto = new EmployeeDto();
                        var index = reader.GetOrdinal("Id");
                        if (index != -1)
                        {
                            employeeDto.Id = Convert.ToInt32(reader.GetValue(index));
                        }
                        index = reader.GetOrdinal("Name");
                        if (index != -1)
                        {
                            employeeDto.Name = Convert.ToString(reader.GetValue(index));
                        }
                        index = reader.GetOrdinal("Salary");
                        if (index != -1)
                        {
                            employeeDto.Salary = Convert.ToInt32(reader.GetValue(index));
                        }
                        yield return employeeDto;
                    }
                }

            }
        }

        public EmployeeDto GetEmployee(int employeeId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var command = new NpgsqlCommand("SELECT * FROM Employee WHERE Id = @id", connection);
                command.Parameters.AddWithValue(@"id", employeeId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         var employeeDto = new EmployeeDto();
                        var index = reader.GetOrdinal("Id");
                        if (index != -1)
                        {
                            employeeDto.Id = Convert.ToInt32(reader.GetValue(index));
                        }
                        index = reader.GetOrdinal("Name");
                        if (index != -1)
                        {
                            employeeDto.Name = Convert.ToString(reader.GetValue(index));
                        }
                        index = reader.GetOrdinal("Salary");
                        if (index != -1)
                        {
                            employeeDto.Salary = Convert.ToInt32(reader.GetValue(index));
                        }
                        return employeeDto;
                    }
                }
            }
            return null;
        }

        public EmployeeDto Add(EmployeeDto employee)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var command = new NpgsqlCommand("INSERT INTO employee (name, salary) VALUES(@name,@salary)", connection);
                command.Parameters.AddWithValue(@"name", employee.Name);
                command.Parameters.AddWithValue(@"salary", employee.Salary);
                employee.Id = command.ExecuteNonQuery();
            }
            return employee;
        }

        public bool Delete(int employeeId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                var command = new NpgsqlCommand("DELETE FROM employee WHERE id=@Id", connection);
                command.Parameters.AddWithValue(@"Id", employeeId);
               if(Convert.ToBoolean(command.ExecuteNonQuery()))
               {
                   return true;
               }
               return false;
            }
        }
    }
}