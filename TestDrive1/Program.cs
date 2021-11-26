using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace TestDrive1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please keep your IE configuration settings:
            // 1. Check on "Enable Protected Mode" at ALL zones in "Security" tab of Internet Options dialog.
            // 2. Browser zoom level keep to 100%.
            var ieOptions = new InternetExplorerOptions
            {
                // Uncomment these lines if you use Microsoft Edge IE mode.
                // AttachToEdgeChrome = true,
                // EdgeExecutablePath = "C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe",
                IgnoreZoomLevel = true,
            };

            using (var driver = new OpenQA.Selenium.IE.InternetExplorerDriver(ieOptions))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                driver.Navigate().GoToUrl("https://www.bing.com/");
                driver.FindElement(By.Id("sb_form_q")).SendKeys("Selenium WebDriver");
                driver.FindElement(By.ClassName("search")).Click();

                Console.WriteLine("OK");
                Console.ReadKey(intercept: true);
            }
        }
    }
}
