using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.DependencyInjectionDemo.Models
{
    public interface Interface
    {
        interface IHome
        {
            public void GoHome();
        }
        interface IHospital
        {
            void GoHospital();
        }
        interface ISchool
        {
            void GoSchool();
        }
    }
}
