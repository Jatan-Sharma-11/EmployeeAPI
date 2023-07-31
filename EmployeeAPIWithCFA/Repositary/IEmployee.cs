using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {

        IEnumerable<Employee> GetAllEmployees();

        List<Employee> GetById(int id);
        Employee AddEmployee(Employee employee);

    }
}
