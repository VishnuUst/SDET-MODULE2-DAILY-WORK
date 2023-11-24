using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver? driver;
        public BunnyCartHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.Id,Using = "search")]
        [CacheLookup]
        private IWebElement? SearchElement { get; set; }
        [FindsBy(How =  How.XPath,Using="//a[@class ='customer-register-link'][1]")]
        [CacheLookup]
        private  IWebElement ?CreateLink { get; set;}
        [FindsBy(How = How.Id,Using = "firstname")]
        private IWebElement ? FirstnameInput { get; set; }
        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastnameInput { get; set; }
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailInput { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }
        [FindsBy(How = How.Name, Using = "password_confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }
        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? CreateAccountButton { get; set; }

        public void ClickCreateAccount()
        {
            CreateLink?.Click();
        }
        public void SignUp(string firstName,string lastName,string email,string password,string confirmPassword,string mobileNumber)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));
            FirstnameInput?.SendKeys(firstName);
            LastnameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);
            Corecodes.ScrollIntoView(driver, PasswordInput);
            PasswordInput?.SendKeys(password);
            ConfirmPasswordInput?.SendKeys(confirmPassword);
            Corecodes.ScrollIntoView(driver, MobileInput);
            MobileInput?.SendKeys(mobileNumber);
        }
        public void CreateAccountButtonClick()
        {
            CreateAccountButton?.Click();
        }
        public SearchResultPage TypeSearchInput(string searchtext)
        {
            /*if(searchtext == null)
            {
                throw new NoSuchElementException(nameof(searchtext));
            }*/
            SearchElement?.SendKeys(searchtext);
            SearchElement?.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }
        

    }
}
