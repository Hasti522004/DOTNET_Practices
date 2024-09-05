using ASP_Web_Application_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Web_Application_MVC.Validator
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.StudentName).NotEmpty().WithMessage("Name not be Empty hahahhahah");
        }
    }
}