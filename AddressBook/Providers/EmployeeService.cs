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
    public class EmployeeSevice:IEmployeeService
    {
        DbService dbService=new DbService();
        public List<Employee> GetEmployees()
        {
            return dbService.GetAllEmployees();
        }
        public bool AddEmployee(Employee newEmployee) {
            return dbService.AddEmployee(newEmployee);
        }
        public Employee GetEmployee(int employeeId)
        {
           return dbService.GetEmployee(employeeId);
        }
        public bool UpdateEmployee(Employee newEmployee)
        {
           return dbService.UpdateEmployee(newEmployee);
        }
        public bool DeleteEmployee(int employeeId)
        {
           return dbService.DeleteEmployee(employeeId);
        }
        public bool ValidateProperties(string propertyName,string property)
        {
            bool status = false;
            switch(propertyName)
            {
                case "Name":
                    Regex name = new Regex(@"^[a-zA-Z]{5,20}$");
                    status = name.Match(property).Success;
                    break;
                case "Email":
                    Regex email = new Regex(@"^([\w\.]+)@([\w]+)((\.(\w){2,3})+)$");
                    status = email.Match(property).Success;
                    break;
                case "Phone":
                    Regex phone = new Regex(@"^[0-9]{10}$");
                    status = phone.Match(property).Success;
                    break;
                case "Landline":
                    Regex landline = new Regex(@"^[0-9]{11}$");
                    status = landline.Match(property).Success;
                    break;
                case "Website":
                    Regex website = new Regex(@"^(https?:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");
                    status = website.Match(property).Success;
                    break;
                case "Address":
                    status = (property.Length > 10);
                    break;
            }
            return status;
        }
    }
}
