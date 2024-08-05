using DOTNET_Practice;
using DestructorDemoNamespace;
namespace Program
{
    class Program
    {
        private double _num;
        public double num
        {
            get
            {
                return _num;
            }
            set
            {
                if (value < 0)
                {
                    throw new exception("please pass positive value");
                }
                else
                {
                    _num = value;
                }
            }
        }
        static void Main(string[] args)
        {

            var singleton = SingletonDesignPattern.Instance(10);
            Console.WriteLine($"SIngleton Pattern Object is {singleton.Id}");

            var singleton2 = SingletonDesignPattern.Instance(20);
            Console.WriteLine($"SIngleton Pattern Object is {singleton2.Id}");


            DestructorDemo obj1 = new DestructorDemo();
            DestructorDemo obj2 = new DestructorDemo();
            // Making obj1 for Garbage Collection
             obj1 = null;
             GC.Collect();

            Program p = new Program();
            p._num = 10;

            Console.WriteLine("Hello World");
        }
    }
}