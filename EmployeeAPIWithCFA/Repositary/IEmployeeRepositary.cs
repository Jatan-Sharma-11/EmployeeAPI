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
        Employee IEmployee.GetById(int id)
        {
            return _EmployeeContext.Employees.Where(p => p.Id == id).FirstOrDefault();
        }

        //public void AddEmployee(Employee employee)
        //{
        //    _EmployeeContext.Add(employee);
        //}
        //   void UpdateEmployee(Employee employee);
        //  void DeleteEmployee(int id);

        //public Employee GetById(int id)
        //{
        //    return EmployeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        //}

    }
}
