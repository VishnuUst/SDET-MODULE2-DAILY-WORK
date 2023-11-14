using Assignment_1_14_11_2023;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
Amazone amazone = new Amazone();
try
{
    amazone.InitializeWebdriver();
    amazone.AmazoneTitleTest();
    amazone.AmazoneOrganizationTesting();
}
catch(AssertionException)
{
    Console.WriteLine("Amazone Title Checking is Failed!!!");
}
amazone.Destruct();
