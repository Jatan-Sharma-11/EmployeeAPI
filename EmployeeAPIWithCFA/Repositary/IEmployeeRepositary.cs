using EmployeeAPIWithCFA.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeAPIWithCFA.Repositary
{
    public class IEmployeeRepositary : IEmployee

    {
        private readonly EmployeeDbContext _EmployeeContext;

        public IEmployeeRepositary(EmployeeDbContext EmployeeContext)
        {
            _EmployeeContext = EmployeeContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _EmployeeContext.Employees.FromSqlRaw("EXEC GetAllEmployee");
        }
        List<Employee> IEmployee.GetById(int id)
        {
            //   return _EmployeeContext.Employees.Where(p => p.Id == id).FirstOrDefault();
            var EmployeeId = new SqlParameter("@EmployeeID", id);
            return _EmployeeContext.Employees.FromSqlRaw("EXEC GetEmployeeByID @EmployeeID", EmployeeId).ToList();
        }

        public Employee AddEmployee(Employee employee)
        {
            _EmployeeContext.Employees.Add(employee);
            _EmployeeContext.SaveChanges();
            return employee;
        }
    }
}
