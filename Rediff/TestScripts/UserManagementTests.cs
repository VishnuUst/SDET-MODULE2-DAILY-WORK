using OpenQA.Selenium.DevTools.V117.Page;
using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : Corecodes
    {
        //Assert
        //[Test,Order(1),Category("Smoke Test")]
        //public void CreateAccountLinkTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    homePage.CreateAccountLinkClick();
        //    //Thread.Sleep(2000);
        //    Assert.That(driver.Url.Contains("register"));

        //}
        //[Test,Order(2),Category("Smoke Test")]
        //public void SignInLinkTest()
        //{
        //    var homepage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");

        //    homepage.SignInLinkClick();
        //    Assert.That(driver.Url.Contains("login"));



        //}
        //[Test, Order(3), Category("Regression Test")]
        //public void CreateAccountFunctionTest()
        //{
        //    var homePage = new RediffHomePage(driver);
        //    if(!driver.Url.Equals("https://www.rediff.com/"))
        //    {
        //        driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    }
           
        //    var createAccountPage=homePage.CreateAccountClick();
        //    Thread.Sleep(2000);
        //    createAccountPage.FullNameType("'xxx");
        //    createAccountPage.EmailType("XXXX");
        //    createAccountPage.CreateAccountClick() ;
        //    Thread.Sleep(3000);
        //    createAccountPage.CreatemyAccountButton();
        //    Thread.Sleep(3000);
          

        //}
        [Test, Order(4), Category("Regression Test")]
        public void SignInFunctionTest()
        {
            var homePage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }

            var signInAccountPage = homePage.SignInClick();
            Thread.Sleep(2000);
            signInAccountPage.TypeUserName("aaa");
            signInAccountPage.TypePassword("123");
            signInAccountPage.ClickRemember();
            Assert.False(signInAccountPage?.Remembermechckbx?.Selected);

            Thread.Sleep(3000);
            signInAccountPage.ClickSignInBtn();
            Thread.Sleep(3000);


        }

    }
}
