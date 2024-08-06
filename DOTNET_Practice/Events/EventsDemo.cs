namespace EventsDemo
{
    delegate string Mydel(string s);
    class EventsDemo
    {
        event Mydel Myevent;
        public EventsDemo()
        {
            this.Myevent += new Mydel(this.Mymethod);
        }
        public string Mymethod(string s)
        {
            return "Welcome " + s;
        }
        public static void Main(string[] args)
        {
            EventsDemo demo = new EventsDemo();
            string mystr = demo.Myevent("Hasti");
            Console.WriteLine(mystr);
        }
    }
}