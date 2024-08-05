namespace AssemblyOne
{
    public class Class1
    {
        internal int Id;
        public void Display()
        {
            Console.WriteLine(Id);
        }
    }
    public class Class2 : Class1
    {
        public void Display2()
        {
            Console.WriteLine(Id);
        }
    }
    public class Class3
    {
        public void Display3()
        {
            Class1 class1 = new Class1();
            Console.WriteLine(class1.Id);
        }
    }
