using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice
{
    internal class GuidDemo
    {
        public static void Main(string[] args)
        {
            // Global Unique Identifier - GUID
            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid);
            Console.ReadKey();
        }
    }
}
