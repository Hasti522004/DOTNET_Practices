﻿namespace WebAPIDemo.MyLogging
{
    public class LogToDB : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("From LogDB");
        }
    }
}
