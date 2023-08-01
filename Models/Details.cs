using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTax.Models
{
    public class Details
    {
         [Key]
        public int Id { get; set; }
        [Required]
        public string ? Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public Employees ? Employees { get; set; }
    }
}