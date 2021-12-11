
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Repository.Models
{
    public class EmployeeDBContext : DbContext
    {

        public EmployeeDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> employee { get; set; }
    }
}
