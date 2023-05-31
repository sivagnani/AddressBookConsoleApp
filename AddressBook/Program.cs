using AddressBook.Contracts;
using AddressBook.Helper;
using AddressBook.Models;
using AddressBook.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEmployeeService empService = new EmployeeSevice();
            Program controlObject = new Program();
            controlObject.DirectoryOptions(empService);
        }
    }
}
