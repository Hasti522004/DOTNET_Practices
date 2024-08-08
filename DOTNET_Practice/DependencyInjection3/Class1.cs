using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.Testing
{
    interface ILogging
    {
        void Log();
    }
    class FileLogging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("File Logging");
        }
    }
    class ConsoleLogging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Console Logging");
        }
    }
    class LoggerUser
    {
        // 1. Constructor Injection
        // Inject the logger dependency through the constructor

        /*
        private ILogging _log;
        public LoggerUser(ILogging ilog)
        {
            _log = ilog;
        }
        */

        //2. Property Injection
        public ILogging _log { get; set; }

        public void Display()
        {
            _log.Log();
        }
    }
    internal class Class1
    {
        public static void Main(string[] args)
        {
            //1. through Constructor injection

            /*
            ILogging logging = new ConsoleLogging();
            LoggerUser user = new LoggerUser(logging);
            user.Display(); 
            */

            // 2. Property Injection
            LoggerUser log = new LoggerUser();
            log._log = new ConsoleLogging();
            log.Display();
            
        }
    }
}
