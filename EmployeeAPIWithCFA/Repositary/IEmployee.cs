using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployees();

        Employee GetById(int id);
          
    }
}
