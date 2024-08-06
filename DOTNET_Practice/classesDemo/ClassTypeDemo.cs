using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.classesDemo
{
    // static class
    static class ClassTypeDemo
    {
        static int x = 1;
        static ClassTypeDemo()
        {
            x = 10;
        }
        public static int Display()
        {
            return x;
        }

    }
    // static class can not inherited
    // static class have only static member
    // we can use static keyword when we do not want to change the value for all the instances

    //sealed class
    sealed class A
    {
        public int x;
        public A()
        {
            x = 1;
        }
        public void Display()
        {
            Console.WriteLine("Hello From sealed class");
        }
    }
    // can not inherit sealed class
    class B
    {
        public int y;
    }

    // partial class
    partial class Partial1
    {
        public int x;
        public Partial1()
        {
            x = 1;
        }
        public void Display1()
        {
            Console.WriteLine("from Partial Class 1");
        }
    }
    partial class Partial1
    {
        public void Display2()
        {
            Console.WriteLine("from Partial Class 2");
        }
    }

    public class NestedDemo
    {
        public class NestedDemo1
        {
            public int x;
            public class NestedDemo2
            {
                public void DisplayNest()
                {
                    Console.WriteLine("from Nested 3");
                }
            }
            public void Display()
            {
                Console.WriteLine(" from Nest 2");
            }
        }
    }
    class StaticClassDemo2
    {
        public int x;
        public static void Main(string[] args)
        {
            // static class
            Console.WriteLine(ClassTypeDemo.Display());

            // sealed class
            A a = new A();
            a.Display();

            //partial class
            Partial1 partial1 = new Partial1();
            partial1.Display2();
            partial1.Display1();

            //Nested class
            NestedDemo.NestedDemo1.NestedDemo2 n = new NestedDemo.NestedDemo1.NestedDemo2();
            n.DisplayNest();

            NestedDemo.NestedDemo1 nn = new NestedDemo.NestedDemo1();
            nn.Display();
        }
    }
}
