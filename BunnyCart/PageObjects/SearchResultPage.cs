using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
   
    internal class SearchResultPage
    {
        IWebDriver? driver;
        public SearchResultPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        /*[FindsBy(How = How.XPath, Using = "(//a[@class='product-item-link'])[position()=2]")]
        
        private IWebElement? FirstProductLink { get; set; }*/
        IWebElement GetProductFirst(string pid)
        {
            return driver.FindElement(By.XPath("(//a[@class='product-item-link'])[position()="+pid+"]"));
        }
        public string? GetFirstProductLink(string id)
        {
            return GetProductFirst(id)?.Text;
        }
        public ProductPage ClickFirstProduct(string id)
        {
            GetProductFirst(id)?.Click();
            return new ProductPage(driver);
        }
    }
}
