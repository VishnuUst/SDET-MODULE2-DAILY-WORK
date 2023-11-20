using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace Amazone_Tests
{
    internal class Amazone
    {
        IWebDriver? _driver;
        public void InitializeChromeWebdriver()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.amazon.com";
            _driver.Manage().Window.Maximize();

        }
        public void InitializeEdgeWebdriver()
        {
            _driver = new EdgeDriver();
            _driver.Url = "https://www.amazon.com";
            _driver.Manage().Window.Maximize();

        }
        public void AmazoneTitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", _driver.Title);
            Console.WriteLine("Title Test - Pass Successful!!!");
        }
        public void LogoTest()
        {
            _driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", _driver.Title);
            Console.WriteLine("Title test for logo test -Pass Successful!!!");


        }
        public void SearchProductTest()
        {
            _driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Mobiles");
            Thread.Sleep(3000);
            _driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : Mobiles").Equals(_driver.Title) && 
                (_driver.Url).Contains("Mobiles"));
            Console.WriteLine("Title Test Of Product And Url Test-Pass Success!!!");

        }
        public void ReloadHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);
        }
        public void TodaysDealTest()
        {
           IWebElement todaysdeals = _driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null)
            {
                throw new NoSuchElementException("Todays deals link not available");
            }
            else
            {
                todaysdeals.Click();
               Assert.That( _driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
                Console.WriteLine("Search Hypertext link-Pass Success!!");
            }
        }
        public void  SignInAccListTest()
        {
            IWebElement hellosignin = _driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello,signin is not present");
            }
            IWebElement accountlists = _driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(accountlists == null)
            {
                throw new NoSuchElementException("Hello,Account list is not present");

            }

                Assert.That(hellosignin.Text.Equals("Hello, sign in"));
                Console.WriteLine("Hello Text Present-Pass Success!!");
                Assert.That(accountlists.Text.Equals("Account & Lists"));
                Console.WriteLine("Accounts & Lists Present-Pass !!");
                

        }
        public void SearchAndFilterProductByBrandTest()
        {
            _driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Mobile Phones");
            Thread.Sleep(3000);
            _driver.FindElement(By.Id("nav-search-submit-button")).Click();
           _driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);
            Assert.True(_driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            
            Console.WriteLine("Motorola is selected-Test Pass");
            _driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"p_89/Google\"]/span/a/div/label/i")).Click();
            Thread.Sleep(3000);

            Assert.True(_driver.FindElement(By.XPath("//*[@id=\"p_89/Google\"]/span/a/div/label/input")).Selected);

            Console.WriteLine("Google is selected -Test Pass");

        }
        public void SelectelementTest()
        {
            IWebElement sortby = _driver.FindElement(By.ClassName("a-native-dropdown.a-declarative"));
            Thread.Sleep(10000);
            SelectElement sort = (SelectElement)sortby;
            sort.SelectByValue("2");
            Thread.Sleep(5000);
            Console.WriteLine(sort.SelectedOption);
        }
        public void Destruct()
        {
            _driver.Close();
        }
    }
}
