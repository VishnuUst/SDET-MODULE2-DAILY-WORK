using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaptolAssignment522112023.PageObjects
{
    internal class SelectProductPage
    {
        IWebDriver? driver;
        public SelectProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using ="//div[@id='productItem5' and @pid='12612074']")]
        public IWebElement Productselect {  get; set; }

        public SelectedProductPage SelectProduct()
        {
            Productselect?.Click();
            return new SelectedProductPage(driver);
        }
    }
}
