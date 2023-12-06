using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using BunnyCart_Bdd;
using OpenQA.Selenium.DevTools;
using Serilog;
using Log = Serilog.Log;
using BunnyCartBDDTest.Hooks;

namespace BunnyCart_Bdd.StepDefinitions
{
    [Binding]

    public class SearchStepDefinitions:Corecodes
    {

        IWebDriver? driver = BeforeHooks.driver;
        [Given(@"User will be on the Homepage")]
        public void GivenUserWillBeOnTheHomepage()
        {
           driver.Url = "https://www.bunnycart.com";
           driver.Manage().Window.Maximize();
        }


        [When(@"User will types the '([^']*)' in the searchbox")]
        public void WhenUserWillTypesTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput =driver.FindElement(By.Id("search"));
            searchInput.SendKeys(searchtext);
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }

        //[When(@"User Clicks on searchbutton")]
        //public void WhenUserClicksOnSearchbutton()
        //{
        //    IWebElement? searchButton = driver.FindElement(By.XPath("(//button[@title='Search'])[position()=1]"));
        //    searchButton.Click();
        //    Thread.Sleep(5000);
        //}

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenShot(driver);
            
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
               LogTestResult("Search Test", $" {searchtext}Test Pass");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search test","Search Test Fail",ex.Message);
            }
        }
        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string searchtext)
        {
            IWebElement ele = driver.FindElement(By.XPath("//h1[@class='page-title']"));
            Assert.That(ele.Text, Does.Contain(searchtext)) ;

        }

        [Then(@"Title should have '([^']*)'")]
        public void ThenUrlShouldHave(string searchtext)
        {
            Assert.That(driver.Title,Does.Contain(searchtext));
        }
        string label;
       

        [When(@"User select a '([^']*)'")]
        public void WhenUserSelectA(string pid)
        {
            IWebElement prod = driver.FindElement(By.XPath("(//a[@class='product-item-link'])[position()=" + pid + "]"));
            label = prod.Text;
            prod.Click();
        }

        [Then(@"Product page is loaded")]
        public void ThenProductPageIsLoaded()
        {
            Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Contains(label));

        }
    }
}
