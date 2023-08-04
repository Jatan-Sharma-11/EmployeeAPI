using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {
        Employee AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        List<Employee> GetById(int id);
        Employee UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);

    }
}
