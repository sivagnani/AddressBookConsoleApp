using AddressBook.Contracts;
using AddressBook.Models;
using AddressBook.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Services;

namespace AddressBook.Helper
{
	public static class MainExtensionMethods
	{
        
		public static void DirectoryOptions(this Program program,IEmployeeService employeeService)
		{
			int option;
			do
			{
				Console.WriteLine("Main Menu");
				Console.WriteLine("1.Add Employee\n2.Show Employees\n3.Exit");
				option=Convert.ToInt32(Console.ReadLine());
				switch (option) { 
					case 1:
						string name = ReadInput(employeeService,"Name");
						string email = ReadInput(employeeService, "Email");
						string phone = ReadInput(employeeService, "Phone");
						string landline = ReadInput(employeeService, "Landline");
						string website = ReadInput(employeeService, "Website");
						string address = ReadInput(employeeService, "Address");
                        Employee newEmployee = new Employee() { Name = name, Email = email, Phone = phone, Landline = landline, Website = website, Address = address };
						if (employeeService.AddEmployee(newEmployee))
						{
							Console.WriteLine("Employee added successfully");
						}
						else
						{
							Console.WriteLine("Error while adding Employee");
						}							
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
                        EmployeeOptions(employeeService,employeeId);
                        break;
					case 3:
						Console.WriteLine("Exiting..........");
						break;
					default: 
						Console.WriteLine("Please Enter Valid Option");
						break;
				}
			} while (option!=3);
		}
		public static void EmployeeOptions(IEmployeeService employeeService,int employeeId)
		{
				Employee employee=employeeService.GetEmployee(employeeId);
				if (employee == null)
				{
					Console.WriteLine("Employee of given ID Not Found");
				}
				else
				{
					Console.WriteLine("Name : " + employee.Name);
					Console.WriteLine("Email : "+ employee.Email);
					Console.WriteLine("Phone : " + employee.Phone);
					Console.WriteLine("Landline : " + employee.Landline);
					Console.WriteLine("Website : " + employee.Website);
					Console.WriteLine("Address : " + employee.Address);
					Console.WriteLine("1. Edit Contact");
					Console.WriteLine("2. Delete Contact");
					Console.WriteLine("3. Go Back");
					int option = Convert.ToInt32(Console.ReadLine());
					switch (option)
					{
						case 1:
							EditOptions(employeeService,employee);
							break;
						case 2:
							if (employeeService.DeleteEmployee(employeeId)) Console.WriteLine("Employee deleted successfully");
							else Console.WriteLine("Error in deleting employee");
							break;
						case 3:
							Console.WriteLine("Going back to Main Menu");
							break;
					}
				}
		}
		public static void EditOptions(IEmployeeService employeeService, Employee employee)
		{
			Employee editEmployee = new Employee() {Id=employee.Id,Name=employee.Name,Email=employee.Email,Phone=employee.Phone,Landline=employee.Landline,Website=employee.Website,Address=employee.Address};
            Console.WriteLine("Choose what you want to Edit");
            Console.WriteLine("1.Name\n2.Email\n3.Phone\n4.Landline\n5.Webiste\n6.Address");
            Console.WriteLine("7. Go Back");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
			{
				case 1:
					editEmployee.Name = ReadInput(employeeService, "Name");
					ConfirmEdit(employeeService,editEmployee);
					break;
                case 2:
					editEmployee.Email = ReadInput(employeeService, "Email");
					ConfirmEdit(employeeService,editEmployee);
					break;
				case 3:
					editEmployee.Phone = ReadInput(employeeService, "Phone");
					ConfirmEdit(employeeService,editEmployee);
					break;
				case 4:
					editEmployee.Landline = ReadInput(employeeService, "Landline");
					ConfirmEdit(employeeService,editEmployee);
					break;
				case 5:
					editEmployee.Website = ReadInput(employeeService, "Website");
					ConfirmEdit(employeeService,editEmployee);
					break;
				case 6:
					editEmployee.Address = ReadInput(employeeService, "Address");
					ConfirmEdit(employeeService,editEmployee);
					break;
                case 7:
                    Console.WriteLine("Going back to Main Menu");
					break;
                }
        }
        public static void ConfirmEdit(IEmployeeService employeeService,Employee employee)
        {
                Console.WriteLine("Name : " + employee.Name);
                Console.WriteLine("Email : " + employee.Email);
                Console.WriteLine("Phone : " + employee.Phone);
                Console.WriteLine("Landline : " + employee.Landline);
                Console.WriteLine("Website : " + employee.Website);
                Console.WriteLine("Address : " + employee.Address);
                Console.WriteLine("1. Confirm Edit");
                Console.WriteLine("2. Cancel");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
					if (employeeService.UpdateEmployee(employee)) Console.WriteLine("Employee Updated Successfully");
					else Console.WriteLine("Error in updating Employee");
					break;
                    case 2:
                        Console.WriteLine("Going back to Main Menu");
					break;
                }
        }
        public static string ReadInput(IEmployeeService service, string propertyName)
        {
            Console.WriteLine("Enter Employee {0}: ", propertyName);
            string propertyValue = Console.ReadLine();
            if (service.ValidateProperties(propertyName, propertyValue)) return propertyValue;
            else
            {
                Console.WriteLine($"{propertyName} is not valid.");
                return ReadInput(service, propertyName);
            }
        }
    }
}
