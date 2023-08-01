using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTax.Models
{

    public class Employees
    {

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public int Salary { get; set; }
        [JsonIgnore]
        public List<Details>? details { get; set; }

  }

}
