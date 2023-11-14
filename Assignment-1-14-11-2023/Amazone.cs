using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_14_11_2023
{
    internal class Amazone
    {
        IWebDriver? _driver;
        public void InitializeWebdriver()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.amazon.com/";
            _driver.Manage().Window.Maximize();
                 
        }
        public void AmazoneTitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", _driver.Title);
            Console.WriteLine("Title Test - Pass Successful!!!");
        }
        public void AmazoneOrganizationTesting()
        {
            Assert.That(_driver.Url.Contains(".com"));
            Console.WriteLine("Amazone Organization Type Test - Pass Successful");
        }
        public void Destruct()

        {
            _driver.Close();
        }
    }
}
