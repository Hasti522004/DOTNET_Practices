using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.Reflection
{
    internal class Reflection
    {
        public static void Main(string[] args)
        {
            Type s = typeof(int);
            Console.WriteLine(s.Name);
            Console.WriteLine(s.FullName);
            Console.WriteLine(s.BaseType);
            Console.WriteLine(s.Namespace);
        }
    }
}
