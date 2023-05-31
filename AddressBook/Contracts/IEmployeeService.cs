using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        bool AddEmployee(Employee newEmployee);
        Employee GetEmployee(int employeeId);
        bool UpdateEmployee(Employee newEmployee);
        bool DeleteEmployee(int employeeId);
        bool ValidateProperties(string propertyName, string property);
    }
}
