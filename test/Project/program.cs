using OpenQA.Selenium;
using OpenQA.Selenium.IE;

using var driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory);

driver.Navigate().GoToUrl("https://www.bing.com/");
driver.FindElement(By.Id("sb_form_q")).SendKeys("Selenium WebDriver");
driver.FindElement(By.Id("sb_form_go")).Click();

Console.WriteLine("OK");
Console.ReadKey(intercept: true);
