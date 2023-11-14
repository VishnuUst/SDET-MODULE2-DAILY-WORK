using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment_2_14_11_2023
{
   
    internal class TestingFunctionality
    {
        IWebDriver? driver;
        public void Initializewebdriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
           
        }
        public void Titlecheck()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Google title-Passed");
        }
        public void GoogleSearchTest()
        {
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
        }
        public void BackToGoogle()
        {
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Back To Google Passed");
        }
       public void SearchGoogle()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("What's the new for Diwali 2023?"); //to type inside the text box
            Thread.Sleep(1000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            googleSearchButton.Click();
            Assert.AreEqual("What's the new for Diwali 2023? - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
            driver.Navigate().Refresh();
        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}
