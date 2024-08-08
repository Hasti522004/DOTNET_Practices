using DOTNET_Practice.DependencyInjection2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.DependencyInjection2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ILogging logging = new ConsoleLogger();
            OrderProcess obj = new OrderProcess(logging);
            obj.Order();
        }
       

    }
}

/*
 You have an application that logs messages to different outputs, such as a file and a console. 
You want to add logging functionality to a class that performs some operations, but you don’t want the
class to be tightly coupled to a specific logging implementation.
 */