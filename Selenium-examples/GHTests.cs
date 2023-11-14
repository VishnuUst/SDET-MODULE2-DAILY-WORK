using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SelfExamples
{
    internal class GHTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

        }

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver(); //browser will open automatically
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }

        public void TitleTest()
        {
            Thread.Sleep(3000); // To wait (10 seconds), only for viewing purpose .Should not include in the final code.
            //Console.WriteLine("title " + driver.Title);
           // Console.WriteLine("Title length " + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }

        public void PageSourceandURLTest()
        {
            //Console.WriteLine("PS Len : " + driver.PageSource.Length);
            //Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Page source and url test - Pass");

        }

        public void GoogleSearchTest()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("hp laptops"); //to type inside the text box
            Thread.Sleep(3000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
           // driver.FindElement(By.PartialLinkText("ma")).Click();

            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail Link - Pass");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            // driver.FindElement(By.LinkText("Gmail")).Click();
            driver.FindElement(By.PartialLinkText("mag")).Click();

            Thread.Sleep(3000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Image Link - Pass");
        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
            // driver.FindElement(By.LinkText("Gmail")).Click();
           string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;

            Thread.Sleep(3000);
            Assert.That(loc.Equals("India"));
            Console.WriteLine("Loc - Pass");
        }
        public void GoogleAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(5000);
           
            driver.FindElement(By.CssSelector("a[href*='youtube']")).Click();////*[@id="yDmH0d"]/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a/div/span
            Thread.Sleep(5000);
            Assert.That("Youtube".Equals(driver.Title));
            
        }

        public void Destruct()
        {
            driver.Close();

        }
    }
}