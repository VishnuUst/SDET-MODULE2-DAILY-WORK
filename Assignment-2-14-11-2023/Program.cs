using Assignment_2_14_11_2023;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

TestingFunctionality testingFunctionality = new TestingFunctionality();
try
{
    testingFunctionality.Initializewebdriver();
    testingFunctionality.Titlecheck();
    testingFunctionality.GoogleSearchTest();
    testingFunctionality.BackToGoogle();
    testingFunctionality.GoogleSearchTest();
    testingFunctionality.BackToGoogle();
    testingFunctionality.SearchGoogle();

}
catch(AssertionException)
{
    Console.WriteLine("Failed");
}
testingFunctionality.Destruct();