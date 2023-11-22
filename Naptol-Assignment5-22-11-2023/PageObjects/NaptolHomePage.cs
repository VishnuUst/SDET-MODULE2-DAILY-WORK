using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaptolAssignment522112023.PageObjects
{
    internal class NaptolHomePage
    {
        IWebDriver driver;
        public NaptolHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? SearchText { get; set; }
        public void SearchTextFunction(string productname)
        {
            SearchText.SendKeys(productname);
            SearchText.SendKeys(Keys.Enter);
        }


    }
}
