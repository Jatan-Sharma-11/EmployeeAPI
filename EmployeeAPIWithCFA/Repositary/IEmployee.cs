using EmployeeAPIWithCFA.Models;

namespace EmployeeAPIWithCFA.Repositary
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetById(int id);
          
       // void AddEmployee(Employee employee);
     //   void UpdateEmployee(Employee employee);
      //  void DeleteEmployee(int id);
    }
}
