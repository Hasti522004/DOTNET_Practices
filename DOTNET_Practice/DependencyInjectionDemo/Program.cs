using DOTNET_Practice.DependencyInjectionDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOTNET_Practice.DependencyInjectionDemo.Models.Interface;

namespace DOTNET_Practice.DependencyInjectionDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IHome home = new Home();
            IHospital hospital = new Hospital();
            ISchool school = new School();
            Person p = new Person(hospital,school,home);
            p.Study();
            p.TakeRest();
            p.Treatment();
        }
    }
}
