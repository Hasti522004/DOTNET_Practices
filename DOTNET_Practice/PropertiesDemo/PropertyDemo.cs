using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.propertiesDemo
{
    class PropertyDemo
    {
        private static string _name;
        static string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        static void Main(string[] args)
        {
            Name = "Hasti";
            Console.WriteLine(Name);
        }
    }
}
