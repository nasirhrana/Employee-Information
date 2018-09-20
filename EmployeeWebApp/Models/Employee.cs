using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

       // [StringLength(10, MinimumLength = 5)]
        [Required( ErrorMessage = "Please Enter Employee ID ")]
        public string EmpId { get; set; }
       [Required(ErrorMessage = "Please Enter Name  ")]
        public string Name { get; set; }

        [Required( ErrorMessage = "Please Enter Email  ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Salary Amount ")]
        [Range(0, Double.MaxValue, ErrorMessage = "Salary should be non-negative number")]
        [DisplayName("Salary")]
        public double Salary { get; set; }

    }
}