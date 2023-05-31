using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(10), MaxLength(10)]
        public string Phone { get; set; }
        [Required]
        [MinLength(11),MaxLength(11)]
        public string Landline { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string Address { get; set; }
        
    }
}
