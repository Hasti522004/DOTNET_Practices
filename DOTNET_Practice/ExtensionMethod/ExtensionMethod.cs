using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOTNET_Practice.ExtensionMethod;

namespace ExtenstionMethodDemo
{
    class ExtensionMethod
    {
        public static void Main(string[] args)
        {
            int a = 10;
            int k = a.GetDigits();
            Console.WriteLine(k);

            string name = "Hasti";
            int j = name.MyString();
            Console.WriteLine(j);
        }
    }
}
