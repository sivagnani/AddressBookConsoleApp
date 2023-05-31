using AddressBook.Contracts;
using AddressBook.Helper;
using AddressBook.Models;
using AddressBook.Providers;
using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            new EmployeeDirectory().Initialize();
        }
    }

    public class EmployeeDirectory
    {
        public EmployeeSevice EmployeeService { get; set; }

        public void Initialize()
        {
            this.EmployeeService = new EmployeeSevice();

            this.MainMenu();
        }

        public void MainMenu()
        {
            try
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1.Add Employee\n2.Show Employees\n3.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        this.AddEmployee();
                        break;

                    case 2:
                        Console.WriteLine("Select employee you want to view");
                        List<Employee> allEmployees = employeeService.GetEmployees();
                        if (allEmployees.Count != 0)
                        {
                            foreach (var employee in allEmployees)
                            {
                                Console.WriteLine("{0}\t{1}", employee.Id, employee.Name);
                            }
                        }
                        else
                            Console.WriteLine("Please Add Employees to see Employees");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        EmployeeOptions(employeeService, employeeId);
                        break;
                    case 3:
                        Console.WriteLine("Exiting..........");
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Option");
                        break;
                }
            }
            catch(Exception ex)
            {
                this.MainMenu();
            }
        }

        public bool AddEmployee()
        {
            try
            {
                Employee employee = new Employee()
                {
                    Name = Extensions.ReadStringInput("Name", true, true)
                }
                        var isSuccess = this.EmployeeService.AddEmployee(employee);
                if (isSuccess)
                    Console.WriteLine("Employee added successfully");
                else
                    Console.WriteLine("Error while adding Employee");
            }catch(Exception ex)
            {
                this.AddEmployee();
            }
        }
    }
}
