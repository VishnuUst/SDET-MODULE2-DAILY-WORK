
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelfExamples;

GHTests gHTests = new GHTests();
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");
foreach (var item in drivers)
{
    switch (item)
    {
        case "Edge":
            gHTests.InitializeEdgeDriver();
            break;
        case "Chrome":
            gHTests.InitializeChromeDriver();
            break;
    }

    /*
    Console.WriteLine("1.Edge 2.Chrome");
    int ch = Convert.ToInt32(Console.ReadLine());
    switch (ch)
    {
        case 1:
            gHTests.InitializeEdgeDriver(); break;
        case 2:
            gHTests.InitializeChromeDriver(); break;
    }*/

    try
    {
        gHTests.TitleTest();
        gHTests.PageSourceandURLTest();
        gHTests.GoogleSearchTest();
        gHTests.GmailLinkTest();
        gHTests.ImagesLinkTest();
        gHTests.LocalizationTest();
        gHTests.GoogleAppYoutubeTest();

    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
}
gHTests.Destruct();