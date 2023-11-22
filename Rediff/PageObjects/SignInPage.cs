using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class SignInPage
    {
        private IWebDriver? driver = null;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);

        }
        //Arrange
        [FindsBy(How = How.Id, Using = "login1")]
        public IWebElement? UserNameText { get; set; }
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? PasswordText { get; set; }
        [FindsBy(How = How.Name, Using = "remember")]
        public IWebElement? Remembermechckbx{ get; set; }
        [FindsBy(How = How.Name, Using = "proceed")]
        public IWebElement? SignInBtn { get; set; }

        public void TypeUserName(string un)
        {
            UserNameText?.SendKeys(un);
        }
        public void TypePassword(string pwd)
        {
            PasswordText?.SendKeys(pwd);
        }
        public void ClickRemember()
        {
            Remembermechckbx?.Click();
        }
        public void ClickSignInBtn()
        {
            SignInBtn?.Click();
        }
    }
       
}
