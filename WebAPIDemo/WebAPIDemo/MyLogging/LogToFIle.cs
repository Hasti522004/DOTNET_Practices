namespace WebAPIDemo.MyLogging
{
    public class LogToFIle : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("From LogToFIle");
        }
    }
}
