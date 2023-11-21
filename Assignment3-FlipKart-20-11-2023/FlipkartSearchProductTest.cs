using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_FlipKart_20_11_2023
{

    internal class FlipkartSearchProductTest : CoreCodeFlipkart
    {
        [Author("Vishnu T")]

        [Test]
        [Order(0)]
        public void SearchProduct()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement locatesearch = fluentwait.Until(search => search.FindElement(By.ClassName("Pke_EE")));
            locatesearch.SendKeys("Laptop");
            locatesearch.SendKeys(Keys.Enter);
            Thread.Sleep(2000);


        }

        [Test]
        [Order(1)]
        public void AddToCartTets()
        {


            IWebElement prodlink = driver.FindElement(By.XPath("//a[@class='_1fQZEK'][1]"));
            prodlink.Click();
            List<string> lswindow = driver.WindowHandles.ToList();

            driver.SwitchTo().Window(lswindow[1]);


        }

        [Test]
        [Order(2)]
        public void AddtoCartButtonTest()
        {
            Thread.Sleep(4000);

        IWebElement e = driver.FindElement(By.XPath("//*[@class='_2KpZ6l _2U9uOA _3v1-ww']"));
        IWebElement v = driver.FindElement(By.ClassName("_352bdz"));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)",v);
            e.Click();
            Thread.Sleep(4000);
        }
    

    }
}
