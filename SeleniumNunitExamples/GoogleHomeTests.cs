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
        //[Ignore("Other")]
        [Test]
        public void GsTest()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);
            List<ExcelData> data = ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var dataItem in data) 
            {
                Console.WriteLine($"Text: {dataItem.SearchText}");
                IWebElement searchInputBox = driver.FindElement(By.Id("APjFqb"));
                searchInputBox.SendKeys(dataItem.SearchText); //to type inside the text box
                Thread.Sleep(3000);
                IWebElement googleSearchButton = driver.FindElement(By.ClassName("gNO89b"));
                googleSearchButton.Click();
                Assert.That(driver.Title, Is.EqualTo(dataItem.SearchText + " - Google Search"));
                Console.WriteLine("GoogleSearchTest - Pass");
                driver.Navigate().GoToUrl("https://www.google.com");
            }
           
            
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
