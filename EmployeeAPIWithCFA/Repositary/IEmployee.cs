using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();

        List<Employee> GetById(int id);
        Employee UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);

    }
}
