// See https://aka.ms/new-console-template for more information
namespace LINQ_Demo
{
    class LINQ_Demo
    {
        public static void Main(string[] args)
        {
            int[] age = { 1, 2, 3, 95, 90, 12, 5, 111, 32 };
            
            var a = from i in age where i > 20 select i;
            a = from i in age where i > 20 orderby i select i;
            a = from i in age where i > 20 orderby i descending select i;
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

            string[] names = { "Hasti", "Jatan", "Riya", "Veer", "Palak", "Jay" };
            var b = from i in names where i.Contains("ha") select i;
            foreach (var i in b) 
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}