using LINQ_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class ExpressionDemo
    {
        public static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            foreach (var i in studentList)
            {
                Console.WriteLine(i.StudentName);
            }
            // Func Delegate
            Func<Student, bool> studentFunc = s => s.Age > 12 & s.Age < 20;

            //Expression represent Strongly typed Lambda Expression
            Expression<Func<Student, bool>> studentExpress = s => s.Age > 12 & s.Age < 20;

            Console.WriteLine();

            Func<Student, bool> isTeen = studentExpress.Compile();

            foreach (var i in studentList)
            {
                bool result = isTeen(i);
                Console.WriteLine(result);
            }

            //let keyword   

            Console.WriteLine("Let Keyword");

            var lowercasestudentlist = from s in studentList
                                       where s.StudentName.ToLower().StartsWith('r')
                                       select s.StudentName.ToLower();

            var letlowercasestudentlist = from s in studentList
                                          let letlist = s.StudentName.ToLower()
                                          where letlist.StartsWith('r')
                                          select letlist;
            foreach (var item in letlowercasestudentlist)
            {
                Console.WriteLine(item);
            }

            // into keyword

            var teenAgerStudents = from s in studentList
                                   where s.Age >= 18 & s.Age < 20
                                   select s
                                       into teenStudents
                                       where teenStudents.StudentName.StartsWith("B")
                                       select teenStudents;

            Console.WriteLine();
            Console.WriteLine("into statement : ");
            foreach (var item in teenAgerStudents)
            {
                Console.WriteLine(item.StudentName);
            }
        }

    }
}
