using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class Actionset : Corecodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("//tr[@class='mouseOut'][1]"));
            Actions actions = new Actions(driver);
            Action mouseOverAction = () => actions.
            MoveToElement(homelink).
            Build().
            Perform();
            Console.WriteLine("Before :" + tdhomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After :" + tdhomelink.GetCssValue("background-color"));
            Thread.Sleep(3000);

        }
        [Test]
        public void MultipleActionTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));
            Actions actions = new Actions(driver);
            Action uppercaseinput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput,"hello")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();
            uppercaseinput.Invoke();
            Console.WriteLine("Text is :" + emailInput.GetAttribute("value"));
            Thread.Sleep(2000);
        }
    }
}
