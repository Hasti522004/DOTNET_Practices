// See https://aka.ms/new-console-template for more information
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
            var b = from i in names where i.Contains("ha") select i; //Not print
            b = from i in names where i.Contains("Ha") select i; //print
            foreach (var i in b) 
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}