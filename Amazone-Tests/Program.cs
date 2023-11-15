
using Amazone_Tests;
using NUnit.Framework;

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
        Thread.Sleep(7000);
    }
    catch(AssertionException)
    {
        Console.WriteLine("Amazone Title Test Failed");
    }
    amazone.Destruct();
}
