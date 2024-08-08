using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.DependencyInjection2.Models
{
    internal class OrderProcess
    {
        private readonly ILogging _logging;
        public OrderProcess(ILogging logging)
        {
            _logging = logging;
        }
        public void Order()
        {
            _logging.Logging();
        }
    }
}
