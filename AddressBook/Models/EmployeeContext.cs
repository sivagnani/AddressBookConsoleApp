using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class EmployeeContext: System.Data.Entity.DbContext
    {
        public EmployeeContext() : base("name=EmployeeDirectory")
        {
            Database.SetInitializer<EmployeeContext>(new DropCreateDatabaseIfModelChanges<EmployeeContext>());
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
