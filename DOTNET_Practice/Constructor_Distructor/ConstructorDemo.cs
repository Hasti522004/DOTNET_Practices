// See https://aka.ms/new-console-template for more information

namespace ConstructorDemo
{
    class ConstructorDemo
    {
        int id;
        string name;
        //1. Default COnstructor
        ConstructorDemo()
        {
            id = 1;
        }
        //2. Parameterized COnstructor
        ConstructorDemo(int i)
        {
            id = i;
        }
        //3. Copy Constructor
        ConstructorDemo(ConstructorDemo obj)
        {
            id = obj.id;
        }
        //Constructor with different Order
        ConstructorDemo(int i, string s)
        {
            id = i;
            name = s;
        }
        ConstructorDemo(string s, int i)
        {
            id = i;
            name = s;
        }
        //4. static Constructor 
        // static Constructor will run first
        // static Constructor always run implicitly (by default)
        // static Constructor is never be parametrized.so can not be override 
        //why not able to Override?
        // The static constructors are executed implicitly and hence we never get a chance to pass a value.
        // And as the static constrictor is the first block to be executed in a class, and hence there is no chance to pass a value.

        // It can only access the static members of the class.

        static ConstructorDemo()
        {
            Console.WriteLine("Static Constructor");
        }

        //5. Private Constructor
        // we can implement singleton pattern
        // use when we have static members only
        // not able to create instance outside the class

        // we can create instance but for that we must have public constructor in case of outside the class
        private ConstructorDemo(string s)
        {
            name = s;
        }
        void Display()
        {
            Console.WriteLine($"id : {id} ; name : {name}");
        }
        //static void Main(string[] args)
        //{
        //    ConstructorDemo instance = new ConstructorDemo(2);
        //    ConstructorDemo instance3 = new ConstructorDemo(3, "Hasti");
        //    ConstructorDemo instance4 = new ConstructorDemo("namra", 4);
        //    ConstructorDemo instance2 = new ConstructorDemo(instance);
        //    ConstructorDemo instance5 = new ConstructorDemo("Jatan");
        //    instance2.Display();
        //    instance3.Display();
        //    instance4.Display();
        //    instance5.Display();
        //    Console.WriteLine(10);
        //}
    }
}
// non static constructor = instance constructor