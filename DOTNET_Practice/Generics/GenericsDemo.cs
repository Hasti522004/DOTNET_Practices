using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.Generics
{
    // Generics is Type independent and type safe ,Increase Code Reusability , Better Performance
    // 1. we can implement diffenrt data types using Object(Poor Performance due to boxing and unboxing)
    // 2. we can do by method overloading (need of repetation of same logic/code)

    // we can apply generics in this cases :
    /*
    Interface
    Abstract 
    Class
    Method
    Static method
    Property
    Event
    Delegates
    */

    // class as generics
    public class Calculator<T>
    {
        public static bool IsEqualCheck(T x, T y)
        {
            return x.Equals(y);
        }
    }

    //method as generics
    public class Calculator
    {
        public static bool IsEqualCheck2<T>(T x, T y)
        {
            return x.Equals(y);
        }
    }

    // class Generic Constraint (Only allow reference type)
    class GenericConstraintDemo<T> where T: class
    {
        public T Message;
        public void GenericMethod(T Param1, T Param2)
        {
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Param1: {Param1}");
            Console.WriteLine($"Param2: {Param2}");
        }
    }

    // struct genetic Constraint (Only allow Value type)
    class StructGenericConstraintDemo<T> where T : struct
    {
        public T Message;
        public void GenericMethod(T Param1, T Param2)
        {
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Param1: {Param1}");
            Console.WriteLine($"Param2: {Param2}");
        }
    }
    class GenericsDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator<int>.IsEqualCheck(1,1));
            Console.WriteLine(Calculator<string>.IsEqualCheck("Hasti", "Hasti"));
            Console.WriteLine(Calculator.IsEqualCheck2<int>(1,2));
            Console.WriteLine(Calculator.IsEqualCheck2<string>("Hasti","Hajipara"));

            //Constraint Demo :

            //1. Class Constraint
            GenericConstraintDemo<string> genericConstraintDemo = new GenericConstraintDemo<string>();

            // in below line int is not reference type, so it will not allow to pass int datatype.
            // GenericConstraintDemo<int> genericConstraintDemo = new GenericConstraintDemo<int>();

            genericConstraintDemo.GenericMethod("Hasti", "Hajipara");

            //2. Struct Constraint
            StructGenericConstraintDemo<int> structGenericConstraintDemo = new StructGenericConstraintDemo<int>();
            StructGenericConstraintDemo<double> structGenericConstraintDemo2 = new StructGenericConstraintDemo<double>();
            // reference type (string ) is not allow
            // StructGenericConstraintDemo<string> structGenericConstraintDemo3 = new StructGenericConstraintDemo<string>();
            structGenericConstraintDemo.GenericMethod(1, 3);
            structGenericConstraintDemo2.GenericMethod(1, 3);

            /*
            where T: new() => only allow public parameterless (default) constructor.
            where T: <base class name> => The type of argument must be or derive from the specified base class.
            where T: <interface name> => The type argument must be or implement the specified interface.
            where T: U => The type argument supplied for must be or derive from the argument supplied for U. 
             */

            // Generic List
            List<string> list = new List<string>();
            list.Add("List1");
            list.Add("list2");

            foreach(string s in list) Console.WriteLine(s);
        }
    }
}
