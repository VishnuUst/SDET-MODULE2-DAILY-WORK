using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class Elements : Corecodes
    {
        [Ignore("Others")]
        [Test]
        public void TestElements()
        {
            Thread.Sleep(3000);
            // IWebElement element = driver.FindElement(By.XPath("//span["));
            // element.Click();
            IWebElement firstname = driver.FindElement(By.Id("firstName"));
            firstname.SendKeys("Vishnu");
            Thread.Sleep(2000);

            IWebElement lastname = driver.FindElement(By.Id("lastName"));
            lastname.SendKeys("T");
            Thread.Sleep(2000);

            IWebElement email = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            email.SendKeys("vishnu@gmail.com");
            Thread.Sleep(2000);

            IWebElement getRadio = driver.FindElement(By.XPath("//label[text()='Male']"));
            getRadio.Click();
            Thread.Sleep(2000);

            IWebElement mobile = driver.FindElement(By.XPath("//input[@id='userNumber']"));
            mobile.SendKeys("1234567891");
            Thread.Sleep(2000);


            IWebElement date = driver.FindElement(By.Id("dateOfBirthInput"));
            date.Click();
            Thread.Sleep(2000);

            IWebElement dbMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            dbMonth.Click();
            Thread.Sleep(2000);

            IWebElement dbYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            dbYear.Click();
            //SelectElement seleyear = new SelectElement(dbYear);
            //seleyear.SelectByText("1998");
            Thread.Sleep(2000);
            IWebElement dbDay = driver.FindElement(By.XPath("//*[@id=\"dateOfBirth\"]/div[2]/div[2]/div/div/div[2]/div[2]/div[3]/div[6]"));
            dbDay.Click();
            Thread.Sleep(2000);
            IWebElement subject = driver.FindElement(By.Id("subjectsInput"));
            subject.SendKeys("Math");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            subject.SendKeys("Chemistry");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            IWebElement gethobby = driver.FindElement(By.XPath("//label[text()='Sports']"));
            gethobby.Click();
            Thread.Sleep(2000);

            IWebElement uploadImage = driver.FindElement(By.Id("uploadPicture"));
            uploadImage.SendKeys(@"C:\\Users\\Administrator\\Desktop\\upimg\\one.jpg");
            Thread.Sleep(2000);

            IWebElement address = driver.FindElement(By.Id("currentAddress"));
            address.SendKeys("Karimpalayil,Payyalakkavu,Chavara,Kollam");
            Thread.Sleep(2000);
            ;            //IWebElement getRadio = driver.FindElement(By.XPath("//span[text()='Check Box']//parent::li"));
            // menu.Click();
            /*List< IWebElement> expandcollaps = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
             foreach(var item in  expandcollaps)
             {
                 item.Click();
             }*/
            //IWebElement commandcheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            //commandcheckbox.Click();
            //Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')"])));
        }
        [Ignore("others")]
        [Test]
        public void WindowTest()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parentwindow ->" + parentWindowHandle);
            IWebElement clickelement = driver.FindElement(By.Id("tabButton"));
            for (var i = 0; i < 3; i++)
            {
                clickelement.Click();
                Thread.Sleep(2000);
            }
            List<string> lswindow = driver.WindowHandles.ToList();
            string lastwindowHandle = "";
            foreach (var handle in lswindow)
            {

                Console.WriteLine("Switching window->" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(20);
                Console.WriteLine("Navigate to google");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(2000);
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        [Ignore("Others")]
        [Test]
        public void AlerTest()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement elem = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", elem);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is" + alertText);
            simpleAlert.Accept();
            Thread.Sleep(2000);

            elem = driver.FindElement(By.Id("confirmButton"));

            elem.Click();
            Thread.Sleep(2000);
            IAlert confirmAlert = driver.SwitchTo().Alert();
            string confirmText = confirmAlert.Text;
            Console.WriteLine("Alert text is" + confirmText);
            confirmAlert.Dismiss();

            elem = driver.FindElement(By.Id("promtButton"));

            elem.Click();
            Thread.Sleep(4000);
            IAlert promAlert = driver.SwitchTo().Alert();
            string promText = promAlert.Text;
            Console.WriteLine("Alert text is" + promText);
            promAlert.SendKeys("Accepting alert");
            Thread.Sleep(6000);
            confirmAlert.Accept();



        }
        [Ignore("Others")]
        [Test]
        public void formtest()
        {
          IWebElement e = driver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scollIntoView(true);", e);
            e.Click();
            Thread.Sleep(2000);
            
        }
    }
 
}
