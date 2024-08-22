using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_First_Approach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(DbModelContainer db = new DbModelContainer())
            {
                tblEmployee temp = new tblEmployee
                {
                    name = "Hasti",
                    age = 30,
                    city = "Ahmedabad"
                };
                db.tblEmployees.Add(temp);
                if (db.SaveChanges() > 0)
                {
                    Console.WriteLine("Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Their is some error");
                }
                Console.ReadKey();
            }
        }
    }
}
