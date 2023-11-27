using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using ExcelDataReader;
using OpenQA.Selenium;
using Serilog;
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

        [Test, Order(1)]
        public void SignUpTest()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilepath = currDir + "/Log/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                WriteTo.Console().
                WriteTo.File(logfilepath,rollingInterval: RollingInterval.Day)
                .CreateLogger();
            BunnyCartHomePage bchp = new(driver);
            bchp.ClickCreateAccount();
            Thread.Sleep(3000);
            try
            {
                Assert.That(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text=="Create an Account",
                    $"Test failed for create account");
                Log.Information("Test passed for create account");
                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for create account.\n Exception:{ex.Message}");
                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");

            }


            // try
            //{

            /*Assert.That(driver.FindElement(By.XPath("//div[" +
                "@class='modal-inner-wrap']//following::h1[2]")).
                Text, Is.EqualTo("Create an Account"));
                bh.SignUp("vishnu", "T", "vishnu98@gmail.com", "1234567", "1234567", "9895302409");
                Thread.Sleep(2000);*/
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/InputData.xlsx";

            string? sheetName = "CreateAccount";



            List<SignUpData> excelDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);



            foreach (var excelData in excelDataList)

            {



                string? firstName = excelData?.FirstName;

                string? lastName = excelData?.LastName;

                string? email = excelData?.Email;

                string? pwd = excelData?.Password;

                string? conpwd = excelData?.ConfirmPassword;

                string? mbno = excelData?.MobileNumber;



                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");





                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);

            }
            Log.CloseAndFlush();
            //catch(AssertionException)
            //{
            //Console.WriteLine("Sign Up Failed");
            // }


            //bh.CreateAccountButtonClick();
        }
        
    }
}
