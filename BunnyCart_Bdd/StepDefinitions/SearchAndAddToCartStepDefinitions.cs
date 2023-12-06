using BunnyCartBDDTest.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart_Bdd.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartStepDefinitions : Corecodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        //string label;
        //[Given(@"Search page is loaded")]
        //public void GivenSearchPageIsLoaded()
        //{
        //    driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water+";
        //}

        //[When(@"User select a '([^']*)'")]
        //public void WhenUserSelectA(string pid)
        //{
        //    IWebElement prod = driver.FindElement(By.XPath("(//a[@class='product-item-link'])[position()=" + pid + "]"));
        //    label =prod.Text;
        //    prod.Click();
        //}

        //[Then(@"Product page is loaded")]
        //public void ThenProductPageIsLoaded()
        //{
        //    Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Contains(label));
           
        //}

    }
}
