
using API_Repository.IRepository;
using API_Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository context)
        {
            this._repo = context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public Task<List<Employee>> Get()
        {
            return _repo.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Task<Employee> Get(int id)
        {
            return _repo.GetEmployeeByID(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _repo.AddEmployee(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _repo.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteEmployee(id);
        }
    }
}
