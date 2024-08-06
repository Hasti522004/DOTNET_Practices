using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.Calculator
{
    delegate void Calculator(int a, int b);
    class DelegatorDemo
    {
        public static void Add(int a,int b)
        {
            Console.WriteLine(a + b);
        }
        public static void Mul(int a,int b)
        {
            Console.WriteLine(a * b);
        }
        public static void Main(string[] args)
        {
            Calculator cal = new Calculator(Add); // Pass method as an Argument
            cal += Mul; // Multicast Delegate (Holds the reference of more than one function)
            cal(10, 20);
            Calculator cal2 = new Calculator(Mul);
            cal2(10, 20);

            // anonymous delegates (without method name)
            Calculator calcadd = delegate (int a, int b)
            {
                Console.WriteLine(a + b);
            };
            calcadd(10, 20);
        }
    }

}
