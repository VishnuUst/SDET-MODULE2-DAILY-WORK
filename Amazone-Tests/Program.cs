
using Amazone_Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.Metadata;

List<string> drivers = new List<string>();
drivers.Add("Chrome");
foreach (var driver in drivers)
{
    Amazone amazone = new Amazone();
    switch (driver)
    {
        case "Edge":
            amazone.InitializeEdgeWebdriver();
            break;
        case "Chrome":
            amazone.InitializeChromeWebdriver();
            break;
  

    }
    try
    {
        amazone.AmazoneTitleTest();
        
        amazone.LogoTest();
       
        ////amazone.SearchProductTest();
       // amazone.ReloadHomePage();
       // amazone.TodaysDealTest();
       // amazone.SignInAccListTest();
        amazone.SearchAndFilterProductByBrandTest();
        amazone .SelectelementTest();
        Thread.Sleep(3000);
    }
    catch(AssertionException)
    {
        Console.WriteLine("Amazone Title Test Failed");
    }
    catch(NoSuchElementException se)
    {
        Console.WriteLine(se.Message);
    }
    amazone.Destruct();
}
