using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart_Bdd.Hooks
{
    public sealed class CommonHooks
    {
        public static IWebDriver? driver;
        
        [BeforeFeature]
        public static void IntializeBrowser()
        {
            driver = new ChromeDriver();



        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }
        [BeforeFeature]
        public static void LogFunctions()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilepath = currDir + "/Log/Search_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        [BeforeScenario]
        public static void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.bunnycart.com");
        }
    }
}
