using OpenQA.Selenium;
using OpenQA.Selenium.IE;

// Please keep your IE configuration settings:
// 1. Check on "Enable Protected Mode" at ALL zones in the "Security" tab of the Internet Options dialog.
//    On Windows 11, you should do that via the Local Group Policy Editor. (see also https://www.urtech.ca/2016/01/solved-how-to-disable-protected-mode-in-internet-explorer-using-gpo/)
// 2. Keep browser zoom level to 100%.
var ieOptions = new InternetExplorerOptions
{
    // These lines are needed to use Microsoft Edge IE mode.
    AttachToEdgeChrome = true,
    EdgeExecutablePath = "C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe",
    IgnoreZoomLevel = true,
};

using var driver = new InternetExplorerDriver(ieOptions);

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
driver.Navigate().GoToUrl("https://www.bing.com/");
driver.FindElement(By.Id("sb_form_q")).SendKeys("Selenium WebDriver");
driver.FindElement(By.ClassName("search")).Click();

Console.WriteLine("OK");
Console.ReadKey(intercept: true);

