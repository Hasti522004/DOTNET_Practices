using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.DependencyInjection2.Models
{
    internal class ConsoleLogger : ILogging
    {
        public void Logging()
        {
            Console.WriteLine("Log in Console Application");
        }
    }
}
