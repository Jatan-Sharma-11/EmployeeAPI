using EmployeeAPIWithCFA.Models;
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
            return _EmployeeContext.Employees.ToList();
        }
        //public Employee GetById(int id)
        //{
        //    return EmployeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        //}
    
    }
}
