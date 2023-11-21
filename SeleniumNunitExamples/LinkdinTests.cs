using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.LayerTree;
using OpenQA.Selenium.DevTools.V117.Storage;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    internal class LinkdinTests : Corecodes
    {
        [Ignore("other")]
        [Test]

        [Author("Vishnu","abc@gmail.com")]
        [Description("Check for Valid Login")]
        [Category("Regression Testing")]
        public void LoginTest1()
        {
            //WebDriverWait webDriverWait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //IWebElement emailInput =webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));

            //IWebElement passwordInput =webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement emailInput = fluentwait.Until(driv=>driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = fluentwait.Until(driv=>driv.FindElement(By.Id("session_password")));
            emailInput.SendKeys("Hari@gmail.com");
            passwordInput.SendKeys("1234");
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);



        }
        /*
        [Test]
        [Author("Gokul","ab@gmail.com")]
        [Description("Check for invalid login")]
        [Category("Smoke Tetsing")]
        public void LogInTestWithInvalidCred2() 
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));
            emailInput.SendKeys("aaa@xyz.com");
            passwordInput.SendKeys("1234");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            emailInput.SendKeys("aa@xyz.com");
            passwordInput.SendKeys("879");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            emailInput.SendKeys("a@xyz.com");
            passwordInput.SendKeys("234");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
        }*/
      /*
       void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        [Ignore("other")]
        [Test]
        [Author("Gokul", "ab@gmail.com")]
        [Description("Check for invalid login")]
        [Category("Smoke Tetsing")]
        //[TestCase("aaa@xyz.com","1234")]
        //[TestCase("aa@xyz.com", "879")]
        //[TestCase("a@xyz.com", "234")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginWithInvalidInput(string email,string password)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement emailInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = fluentwait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            TakeScreenShot();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",
                driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);
            js.ExecuteScript("arguments[0].click();",
               driver.FindElement(By.XPath("//button[@type='submit']")));
            TakeScreenShot();
            ClearForm(emailInput);
            ClearForm(passwordInput);

        }
       /* static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[]{"abc@xyz.com","1234"},
                new object[]{"yyy@xyz.com","5678"},
            };
        }*/
       
    }//arguments[0].scrollintoview(true);
}
