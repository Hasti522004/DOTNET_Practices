﻿using ASP_Web_Application_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Web_Application_MVC.Controllers
{
    public class StudentController : Controller
    {
        static IList<Models.Student> studentlist = new List<Models.Student> { 
            new Models.Student() {StudentId = 1, StudentName="Hasti",Age=18},
            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
        };
        // GET: Student
        public ActionResult Index()
        {
            return View(studentlist.OrderBy(s => s.StudentId).ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var std = studentlist.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                var student = studentlist.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
                studentlist.Remove(student);
                studentlist.Add(std);
                return RedirectToAction("Index");
            }
            return View(std);
        }
    }
}