using BunnyCart.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.BunnyCartTests
{
    [TestFixture]
    internal class Searchtests : Corecodes
    {
        [Test, Order(0)]
        [TestCase("Water Poppy","2")]
        public void SearchProductAndAddToCartTest(string productName,string id)
        {
            BunnyCartHomePage bch = new(driver);
            var searrespage = bch?.TypeSearchInput(productName);
            //Actions actions = new Actions(driver);
            //Action action = () =>actions.MoveToElement()

            Corecodes.ScrollIntoView(driver,driver.FindElement(By.XPath("//*[@id=\"amasty-shopby-product-list\"]/div[2]/ol/li[1]")));
            Thread.Sleep(2000);
           Assert.That(productName.Contains(searrespage?.GetFirstProductLink(id)));
            var prodpage = searrespage?.ClickFirstProduct(id);
            Assert.That(productName.Equals(prodpage?.GetProductTitlelabel()));
            prodpage?.ClickIncQtyLink();
            prodpage?.ClickAddToCartButton();
            Thread.Sleep(3000);
        }
    }

}
