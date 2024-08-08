using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOTNET_Practice.DependencyInjectionDemo.Models.Interface;

namespace DOTNET_Practice.DependencyInjectionDemo.Models
{
    public class Person
    {
        private IHome _home;
        private IHospital _hospital;
        private ISchool _school;

        public Person(IHospital hospital, ISchool school,IHome home)
        {
            _hospital = hospital;
            _school = school;
            _home = home;
        }

        public void TakeRest()
        {
            _home.GoHome();
        }
        public void Study()
        {
            _school.GoSchool();
        }
        public void Treatment()
        {
            _hospital.GoHospital();
        }
    }
}
