// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

namespace LINQ_Demo
{
    class LINQ_Demo
    {
        public static void Main(string[] args)
        {
            // LINQ-To-Objects
            int[] age = { 1, 2, 3, 95, 90, 12, 5, 111, 32 };

            // 1. Query Syntax
            IEnumerable<int> a = from i in age where i > 20 select i;
            a = from i in age where i > 20 orderby i select i;
            a = from i in age where i > 20 orderby i descending select i;
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("---------------------------------------");

            // 2. Method Syntax
            var methodSyntax = age.Where(i => i > 20);
            foreach (var i in methodSyntax)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine("---------------------------------------");

            // 3. Mixed Syntax
            var mixedSyntax = (from i in age
                               select i).Max();

            Console.WriteLine(mixedSyntax);

            string[] names = { "Hasti", "Jatan", "Riya", "Veer", "Palak", "Jay" };
            //Case sensetive
            var b = from i in names where i.Contains("ha") select i; //Not print
            b = from i in names where i.Contains("Ha") select i; //print

            Console.WriteLine();

            var k = names.Where(s => s.Contains("a"));

            foreach(var i in k)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();

            foreach (var i in b) 
            {
                Console.WriteLine(i);
            }
            
            //Demo of Multiple Records
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id=1,Name="Hasti",Email="hasti.hajipara@gmail.com"},
                new Employee(){Id=1,Name="Namra",Email="hasti.hajipara@gmail.com"},
                new Employee(){Id=1,Name="Hasti",Email="hasti.hajipara@gmail.com"},
                new Employee(){Id=1,Name="Hasti",Email="hasti.hajipara@gmail.com"}

            };

            var basicQuery = (from emp in employees
                             select emp.Id).ToList();

           // var basicMethod = employees.ToList();
            var basicMethod = employees.Select(emp => emp.Id).ToList();
            foreach (var item in basicQuery)
            {
                Console.WriteLine($"ID = {item}");
            }
            foreach (var item in basicMethod)
            {
                Console.WriteLine($"ID = {item}");
            }

            //group by
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            var groupQuery = from s in studentList
                             group s by s.Age;
            var groupMethod = studentList.GroupBy(s => s.Age).ToList();
            foreach (var item in groupQuery)
            {
                Console.WriteLine("Age Group: {0}",item.Key);

                foreach (var student in item) 
                {
                    Console.WriteLine("Student Name : {0}",student.StudentName);
                }
            }
            Console.ReadKey();
        }
    }
}