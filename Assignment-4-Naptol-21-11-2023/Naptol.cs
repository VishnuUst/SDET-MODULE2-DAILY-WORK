using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Assignment_4_Naptol_21_11_2023
{
    internal class Naptol : CoreCodeNaptol
    {
        [Order(1)]
        [Test]
        public void SearchTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement searchelement = fluentwait.Until(x => x.FindElement(By.Id("header_search_text")));
            searchelement.SendKeys("eyewear");
            Assert.IsTrue(true);
            searchelement.SendKeys(Keys.Enter);
        }
        [Order(2)]
        [Test]
        [TestCase(5)]
        public void SelectProductTest(int pid)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            string path = "//div[@id='productItem" + pid + "']";
            IWebElement fndProductfive = fluentwait.Until(x => x.FindElement(By.XPath(path)));
            Actions actions = new Actions(driver);
            Action action = () => actions.MoveToElement(fndProductfive).
            Click().
            Build().
            Perform();
            action.Invoke();
            Thread.Sleep(3000);
            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);
            Assert.IsTrue(lswindow.Count > 0);
        }
        [Order(3)]
        [Test]
        public void Selectsize()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement selectSize = fluentwait.Until(x => x.FindElement(By.XPath("//a[text()='Black-3.00']")));
            Actions actions = new Actions(driver);
            Action action = () => actions.MoveToElement(selectSize).
            Click().
            Build().
            Perform();
            Thread.Sleep(20);
            action.Invoke();
            Assert.AreEqual("Buy Reading Glasses with LED Lights (LRG4) Online at Best Price in India on Naaptol.com", driver.Title);
        }
        [Order(4)]
        [Test]
        public void AddtoCartTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement buybutton = fluentwait.Until(x => x.FindElement(By.XPath("//a[@id='cart-panel-button-0']")));
            Actions btnactions = new Actions(driver);
            Action btnaction =  () => btnactions.MoveToElement(buybutton).
            Click().
            Build().
            Perform();
            
            btnaction.Invoke();
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4"));
            Thread.Sleep(3000);

        }
        [Order(5)]
        [Test]
        public void CloseTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";

            IWebElement closebtn = fluentwait.Until(x => x.FindElement(By.XPath("//a[@class='fancybox-item fancybox-close']")));
            IWebElement id = driver.FindElement(By.XPath("//*[text()='My Shopping Cart: ']"));
            Console.WriteLine(id.Text);
            Assert.That(id.Text=="My Shopping Cart: At present, you have (1) items.");
            Console.WriteLine("sussess");
            closebtn.Click();
            Thread.Sleep(2000);
           
        }
        

    }
}
