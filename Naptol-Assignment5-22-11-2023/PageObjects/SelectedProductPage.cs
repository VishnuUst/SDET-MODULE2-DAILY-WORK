using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaptolAssignment522112023.PageObjects
{
    internal class SelectedProductPage
    {
        IWebDriver? driver;
        public SelectedProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));

            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//a[text()='Black-3.00']")]
        public IWebElement? SelectedSize { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@id='cart-panel-button-0']")]
        public IWebElement BuyNowSelected { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='fancybox-item fancybox-close']")]
        public IWebElement CloseBtn { get; set; }

        public void Sizeselect()
        {
            SelectedSize?.Click();
        }
        public void BuyNowButtonClicked()
        {
            BuyNowSelected?.Click();
        }
        public void CloseButtonClicked()
        {
            CloseBtn?.Click();
        }

    }
}
