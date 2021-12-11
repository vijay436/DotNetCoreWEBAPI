using API_Repository.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByID(int Id);
        Task<string> AddEmployee(Employee employee);
        Task<string> UpdateEmployee(Employee employee);

        Task<int> DeleteEmployee(int? Id);

    }
}
