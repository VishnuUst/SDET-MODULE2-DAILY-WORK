using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class GoogleHomeTests : Corecodes
    {
        [Ignore("Other")]
        [Test]
        public void CheckForTitle()
        {

            Thread.Sleep(2000);
            string title = driver.Title;
            Assert.AreEqual("Google", title);
        }
        [Ignore("Other")]
        [Test]
        public void GsTest()
        {
            IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
            searchInputBox.SendKeys("hp laptops"); //to type inside the text box
            Thread.Sleep(3000);
            IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
            googleSearchButton.Click();
            Assert.AreEqual("hp laptops - Google Search", driver.Title);
            Console.WriteLine("GoogleSearchTest - Pass");
        }
        [Ignore("Other")]
        [Test]
        public void AllLinkStatusTest()
        {
            List<IWebElement> aLinks =driver.FindElements(By.TagName("a")).ToList();
            foreach(var data in aLinks)
            {
              string url = data.GetAttribute("href");
                if(url == null)
                {
                    Console.WriteLine("url is nulll");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkSatus(url);
                    if(isworking)
                    {
                        Console.WriteLine(url + "is working");
                    }
                    else
                    {
                        Console.WriteLine(url + " is Not Working");
                    }
                }
            }
        }
    }
}
