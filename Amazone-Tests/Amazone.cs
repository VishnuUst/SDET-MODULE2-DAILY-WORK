using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace Amazone_Tests
{
    internal class Amazone
    {
        IWebDriver? _driver;
        public void InitializeChromeWebdriver()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.amazon.com/";
            _driver.Manage().Window.Maximize();

        }
        public void InitializeEdgeWebdriver()
        {
            _driver = new EdgeDriver();
            _driver.Url = "https://www.amazon.com/";
            _driver.Manage().Window.Maximize();

        }
        public void AmazoneTitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", _driver.Title);
            Console.WriteLine("Title Test - Pass Successful!!!");
        }
        public void Destruct()
        {
            _driver.Close();
        }
    }
}
