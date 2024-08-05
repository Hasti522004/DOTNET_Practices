using DOTNET_Practice;
using DestructorDemoNamespace;
namespace Program
{
    class Program
    {
        //properties Example
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

        // Struct demo
        struct Person
        {
            public string name;
            public int age;
            public int id;
        }

        //enum
        public enum Product
        {
            Milk = 0, Juice = 1, Tea = 2
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

            Person Person1;
            Person1.age = 20;
            Person1.name = "Test";
            Person1.id = 10;

            Console.WriteLine("Age : " + Person1.age);

            // enum 
            var test1 = Product.Tea;
            var test2 = Product.Milk;
            Console.WriteLine((int)test1 + " " + test2);

            string test3 = "Tefa";
            Product getProduct;
            bool checkParse = Enum .TryParse(test3 , out getProduct);
            Console.WriteLine(checkParse);
        }
    }
}