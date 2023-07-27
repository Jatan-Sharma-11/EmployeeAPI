using EmployeeAPIWithCFA.Models;
using System.Linq.Expressions;

namespace EmployeeAPIWithCFA.Repositary
{
    public class IEmployeeRepositary : IEmployee

    {
        private readonly EmployeeDbContext EmployeeContext;
        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>();
        }
        public Employee GetById(int id)
        {
            return EmployeeContext.Employees.Where(x => x.Id == id).FirstOrDefault();
        }
    
    }
}
