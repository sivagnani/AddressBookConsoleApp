using AddressBook.Contracts;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook.Providers
{
    public class DbService
    {
        EmployeeContext context = new EmployeeContext();
        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList<Employee>();
        }
        public bool AddEmployee(Employee newEmployee) {
            bool status= false;
            try
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
            }
            return status;
        }
        public Employee GetEmployee(int employeeId)
        {
            try
            {
                return context.Employees.Find(employeeId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UpdateEmployee(Employee newEmployee)
        {
            bool status = false;
            try
            {
                Employee updateEmployee = context.Employees.Find(newEmployee.Id);
                updateEmployee.Name = newEmployee.Name;
                updateEmployee.Email = newEmployee.Email;
                updateEmployee.Phone = newEmployee.Phone;
                updateEmployee.Landline= newEmployee.Landline;
                updateEmployee.Website = newEmployee.Website;
                updateEmployee.Address = newEmployee.Address;
                context.SaveChanges();
                status= true;
            }
            catch (Exception ex)
            {
            }
            return status;
            
        }
        public bool DeleteEmployee(int employeeId)
        {
            bool status = false;
            try
            {
                context.Employees.Remove(context.Employees.Find(employeeId));
                context.SaveChanges();
                status= true;
            }
            catch(Exception ex)
            {
            }
            return status;
        }
    }
}
