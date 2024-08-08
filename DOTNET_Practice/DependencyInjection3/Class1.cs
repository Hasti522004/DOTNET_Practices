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
        private ILogging _log;
        public LoggerUser(ILogging ilog)
        {
            _log = ilog;
        }
        public void Display()
        {
            _log.Log();
        }
    }
    internal class Class1
    {
        public static void Main(string[] args)
        {
            ILogging logging = new ConsoleLogging();
            LoggerUser user = new LoggerUser(logging);
            user.Display(); 
        }
    }
}
