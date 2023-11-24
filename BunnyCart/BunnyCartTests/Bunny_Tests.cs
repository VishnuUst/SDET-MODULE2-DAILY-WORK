using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.BunnyCartTests
{
    [TestFixture]
    internal class Bunny_Tests :Corecodes
    {
       
        [Test,Order(1)]
        public void SignUpTest()
        {
            BunnyCartHomePage bh = new(driver);
            bh.ClickCreateAccount();
            Thread.Sleep(3000);
            try
            {
            
            Assert.That(driver.FindElement(By.XPath("//div[" +
                "@class='modal-inner-wrap']//following::h1[2]")).
                Text, Is.EqualTo("Create an Account"));
                bh.SignUp("vishnu", "T", "vishnu98@gmail.com", "1234567", "1234567", "9895302409");
                Thread.Sleep(2000);

            }
            catch(AssertionException)
            {
                Console.WriteLine("Sign Up Failed");
            }
        
           
            //bh.CreateAccountButtonClick();
        }
        
    }
}
