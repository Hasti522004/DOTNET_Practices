using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOTNET_Practice.DependencyInjectionDemo.Models.Interface;

namespace DOTNET_Practice.DependencyInjectionDemo.Models
{
    public class Home : IHome
    {
        public void GoHome()
        {
            Console.WriteLine("At Home");
        }
    }
}
