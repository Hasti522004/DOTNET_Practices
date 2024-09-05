using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Web_Application_MVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        // [Required(ErrorMessage = "Please Enter Name as Hasti...")]
        public string StudentName { get; set; }
        // [Required]
        public int Age { get; set; }
        public string email { get; set; }
    }
}