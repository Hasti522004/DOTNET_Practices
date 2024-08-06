using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.methodCallingDemo
{
    class MethodCallingDemo
    {
        static void Method1(ref int x)
        {
            Console.WriteLine(x);
            x = 100;
            Console.WriteLine(x);

        }

        static void Method2(int x)
        {

        }

        static void Method3(out int x)
        {
            x = 23;
        }
        static void Method4(int x,params int[] ars)
        {
            
        }
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Method Calling Demo");
            int a = 10;
            Console.WriteLine(a);
            Method2(a); // call by value
            Method1(ref a); // call by reference
            Method3(out a); // call by output
            Method4(1000); // call by params
            Method4(1000, 23, 23, 134);
            Console.WriteLine(a);
        }
    }
}
