using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_Practice.ExceptionHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 1;
            int c;
            try
            {
                Console.WriteLine("A VALUE = " + a);
                Console.WriteLine("B VALUE = " + b);
                c = a / b;
                Console.WriteLine("C VALUE = " + c);
                if(b%2 != 0)
                {
                    throw new OddNumberException("from my class Odd number not allow Exeption");
                }
                Console.ReadKey();
            }
            catch(OddNumberException ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"HelpLink: {ex.HelpLink}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            try
            {
                int FirstNumber, SecondNumber, Result;
                //Inner Try
                try
                {
                    //Make sure to Cause Exception in the Try Block
                    Console.WriteLine("Enter First Number:");
                    FirstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Second Number:");
                    SecondNumber = Convert.ToInt32(Console.ReadLine());
                    Result = FirstNumber / SecondNumber;
                    Console.WriteLine($"Result = {Result}");
                }
                //Inner Catch
                catch (Exception ex)
                {
                    //Make sure this Path Does Not Exist
                    string filePath = @"D:\Projects\LogFile\Log.txt";
                    if (File.Exists(filePath))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append($"Message: {ex.Message} \n");
                        stringBuilder.Append($"Source: {ex.Source} \n");
                        stringBuilder.Append($"HelpLink: {ex.HelpLink} \n");
                        stringBuilder.Append($"StackTrace: {ex.StackTrace} \n");
                        stringBuilder.Append($"GetType(): {ex.GetType()} \n");
                        stringBuilder.Append($"GetType().Name: {ex.GetType().Name} \n");

                        StreamWriter streamWriter = new StreamWriter(filePath);
                        streamWriter.Write(stringBuilder.ToString());
                        streamWriter.Close();
                        Console.WriteLine("There is a Problem! Plese Try Later");
                    }
                    else
                    {
                        //To retain the Original Exception pass, this exceptiopm as a parameter
                        //to the constructor of the current exception
                        string Message = filePath + " Does Not Exist";
                        throw new FileNotFoundException(Message, ex);
                    }
                }
            }
            //Outer Catch
            catch (Exception exception)
            {
                //exception.Message will give the current exception message
                //i.e. Message about File Not Found Exception
                Console.WriteLine("\nCurrent Exception Details: ");
                Console.WriteLine($"Current Exception Message: {exception.Message}");
                Console.WriteLine($"Current Exception Source: {exception.Source}");
                Console.WriteLine($"Current Exception StackTrace: {exception.StackTrace}");
                //Check if InnerException is not null before accessing the InnerException properties
                //else, you may get Null Reference Excception
                if (exception.InnerException != null)
                {
                    Console.WriteLine("\nInner Exception Details: ");
                    Console.WriteLine($"Inner Exception Message: {exception.InnerException.Message}");
                    Console.WriteLine($"Inner Exception Source: {exception.InnerException.Source}");
                    Console.WriteLine($"Inner Exception StackTrace: {exception.InnerException.StackTrace}");
                }
            }
            Console.WriteLine("Main Method End");
            Console.ReadLine();
        }

    
    }
    public class OddNumberException : Exception
    {   
        public OddNumberException() 
        {
            
        }
        public OddNumberException(string message) : base(message)
        {

        }
        public OddNumberException(string message, Exception innerException) : base(message, innerException) { }
        //public override string Message
        //{
        //    get
        //    {
        //        return "Divisor can not be Odd Number";
        //    }
        //}
   
        public override string? HelpLink {
            get
            {
                return "Help Desk for Exception";
            }
        }
    }
}
