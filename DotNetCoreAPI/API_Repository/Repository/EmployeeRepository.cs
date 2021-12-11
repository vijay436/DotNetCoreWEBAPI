using API_Repository.IRepository;
using API_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDBContext _ctx;
        public EmployeeRepository(EmployeeDBContext context)
        {
            this._ctx = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _ctx.employee.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByID(int Id)
        {
            return await _ctx.employee.FindAsync(Id);
        }
        public async Task<string> AddEmployee(Employee employee)
        {
            await _ctx.employee.AddAsync(employee);
            await _ctx.SaveChangesAsync();
            return "Saved successfully..";
        }

        public async Task<string> UpdateEmployee(Employee employee)
        {
            _ctx.Entry(employee).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return "Updated successfully..";
        }

        public async Task<int> DeleteEmployee(int? Id)
        {
            int result = 0;

            if (_ctx != null)
            {
                //Find the post for specific employee id
                var employee = await _ctx.employee.FirstOrDefaultAsync(x => x.Id == Id);

                if (employee != null)
                {
                    //Delete that employee
                    _ctx.employee.Remove(employee);

                    //Commit the transaction
                    result = await _ctx.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

    }
}
