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

        public EmployeeController(IEmployee EmployeeRepositary)
        {
            _IEmployeeRepositary = EmployeeRepositary;
        }

        [HttpPost]
        [Route("AddNewEmployee")]
        public IActionResult AddNewEmployee(Employee employee)
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
        public async Task<IActionResult> GetAllEmployees()
        {
            var items = await _IEmployeeRepositary.GetAllEmployeesAsync();
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
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = _IEmployeeRepositary.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound("Wrong Id input");
            }
            else
            {
                _IEmployeeRepositary.UpdateEmployee(employee);
                return Ok("Employee Details Updated Successfully");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            bool deleted = _IEmployeeRepositary.DeleteEmployee(id);
            if (deleted)
            {
                return Ok("Employee Details Deleted Successfully");
            }
            else
            {
                return NotFound("Employee Data Not Found");
            }
        }
    }
}
