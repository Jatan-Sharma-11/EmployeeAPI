﻿using EmployeeAPIWithCFA.Models;
using EmployeeAPIWithCFA.Repositary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIWithCFA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployeeRepositary;
        private readonly EmployeeDbContext EmployeeContext;

        public EmployeeController(EmployeeDbContext EmployeeContext, IEmployee EmployeeRepositary)
        {
            this.EmployeeContext = EmployeeContext;
            _IEmployeeRepositary = EmployeeRepositary;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public string AddEmployee(Employee Emp)
        {
            string response = string.Empty;
            EmployeeContext.Employees.Add(Emp);
            EmployeeContext.SaveChanges();
            return "Employee Details Added Successfully";
        }
        [HttpGet]
        [Route("Get")]
        [HttpGet]
        public IActionResult Get()
        {
            var items = _IEmployeeRepositary.GetAllEmployees();
            return Ok(items);
        }
        [HttpGet]
        [Route("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return EmployeeContext.Employees.ToList();
        }

        [HttpGet]
        [Route("GetEmployee")]

        public Employee GetEmployee(int id)
        {
            return EmployeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public string UpdateEmployee(Employee emp)
        {
            EmployeeContext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            EmployeeContext.SaveChanges();
            return "Employee Record Updated Successfully";
        }

        [HttpDelete]
        [Route("DeleteEmployee")]

        public string DeleteEmployee(int id)
        {
            Employee Emp = EmployeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (Emp != null)
            {
                EmployeeContext.Employees.Remove(Emp);
                EmployeeContext.SaveChanges();
                return "Employee Details Deleted Successfully";
            }
            else
            {
                return "Employee Data Not Found";
            }

        }
    }
}
