﻿using EmployeeAPIWithCFA.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using static EmployeeAPIWithCFA.Repositary.IEmployeeRepositary;

namespace EmployeeAPIWithCFA.Repositary
{
    public class IEmployeeRepositary : IEmployee

    {
        private readonly EmployeeDbContext _EmployeeContext;

        public IEmployeeRepositary(EmployeeDbContext EmployeeContext)
        {
            _EmployeeContext = EmployeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            var Name = new SqlParameter("@Name", employee.Name);
            var Designation = new SqlParameter("@Designation", employee.Designation);
            _EmployeeContext.Database.ExecuteSqlRaw("Exec InsertEmployee @Name, @Designation",Name,Designation);
            var insertedEmployee = _EmployeeContext.Employees.FromSqlRaw("SELECT * FROM Employees WHERE Name = @Name AND Designation = @Designation", Name, Designation).FirstOrDefault();

            if (insertedEmployee != null)
            {
                employee.Id = insertedEmployee.Id;
            }
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _EmployeeContext.Employees.FromSqlRaw("EXEC GetAllEmployee");
        }
        List<Employee> IEmployee.GetById(int id)
        {
            var EmployeeId = new SqlParameter("@EmployeeID", id);
            return _EmployeeContext.Employees.FromSqlRaw("EXEC GetEmployeeByID @EmployeeID", EmployeeId).ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var Id = new SqlParameter("@Id", employee.Id);
            var Name = new SqlParameter("@Name", employee.Name);
            var Designation = new SqlParameter("@Designation", employee.Designation);
            _EmployeeContext.Database.ExecuteSqlRaw("Exec UpdateEmployee @Id, @Name, @Designation", Id, Name, Designation);
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            Employee emp = _EmployeeContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                var EmployeeId = new SqlParameter("@id", id);
                _EmployeeContext.Database.ExecuteSqlRaw("EXEC DeleteEmployee @id", EmployeeId);
                _EmployeeContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
