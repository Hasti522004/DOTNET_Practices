using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.ExtensionMethod
{
    // Extension Method must be define in static class
    static class Class1
    {
        public static int GetDigits(this int num)
        {
            int count = 0;
            while(num!=0)
            {
                count++;
                num = num/10;
            }
            return count;
        }
        public static int MyString(this string name)
        {
            return 10;
        }
    }
}
