using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver? driver;
        public ProductPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//h1[@class='page-title']")]
        private IWebElement? ProductTitle { get; set; }
        [FindsBy(How = How.ClassName,Using ="qty-inc")]
        private IWebElement?IncQty{ get; set; }
        [FindsBy(How = How.Id,Using ="product-addtocart-button")]
        private IWebElement? AddToCartBtn{ get; set; }

        public string? GetProductTitlelabel()
        {
            return ProductTitle?.Text;
        }
        public void ClickIncQtyLink()
        {
            IncQty?.Click();
        }
        public void ClickAddToCartButton()
        {
            AddToCartBtn?.Click();
        }
    }
}
