using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();

      //  Employee GetById(int id);
          
    }
}
