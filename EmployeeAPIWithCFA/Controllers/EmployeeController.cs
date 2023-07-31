using EmployeeAPIWithCFA.Models;
using EmployeeAPIWithCFA.Repositary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult PostEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _IEmployeeRepositary.AddEmployee(employee);
                return Ok(employee);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var items = _IEmployeeRepositary.GetAllEmployees();
            return Ok(items);
        }

        [HttpGet]
        [Route("GetEmployee")]

        public IActionResult GetEmployee(int id)
        {
            var item = _IEmployeeRepositary.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
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
