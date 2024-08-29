using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

class Program
{
    static void Main()
    {
        var edgeOptions = new EdgeOptions();

        // Optional: Specify the user data directory and profile directory if necessary
        edgeOptions.AddArgument("--user-data-dir=C:\\Users\\HASTIH~1\\AppData\\Local\\Microsoft\\Edge\\User Data");
        edgeOptions.AddArgument("--profile-directory=Default");

        // Specify the path to the EdgeDriver executable if it's not in your system PATH
        var service = EdgeDriverService.CreateDefaultService("path-to-your-edgedriver");

        using (var driver = new EdgeDriver(service, edgeOptions))
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.bing.com");
                Console.WriteLine("Browser started successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
