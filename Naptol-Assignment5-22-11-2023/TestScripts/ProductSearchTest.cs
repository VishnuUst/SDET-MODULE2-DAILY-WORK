using NaptolAssignment522112023.PageObjects;
using NaptolAssignment522112023.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaptolAssignment522112023.TestScripts
{
    [TestFixture]
    internal class ProductSearchTest : Corecodes
    {
        [Test,Order(1)]
        public void SearchTest()
        {
            var naptolhomepage = new NaptolHomePage(driver);

            if(!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDir + "/TestSearchData/InputSearchData.xlsx";

            string? sheetName = "SearchProduct";
            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)

            {
                string? searchData = excelData.SearchText;
                Console.WriteLine($"Search Data :{searchData}");
                naptolhomepage.SearchTextFunction(excelData.SearchText);
                Thread.Sleep(3000);
                TakeScreenShot();
                Assert.IsNotNull( searchData );

                var enterkey = naptolhomepage.EnterFunction();
                var selectprod = new SelectProductPage(driver);
                selectprod.SelectProduct();
                Assert.That(driver.Url.Contains("eyewear"));
                List<string> lswindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow[1]);
                Thread.Sleep(2000);
                var sprodd =  new SelectedProductPage(driver);
                sprodd.Sizeselect();
                
                Thread.Sleep(2000);
                sprodd.BuyNowButtonClicked();
                Thread.Sleep(2000);
                sprodd.CloseButtonClicked();
                Thread.Sleep(2000);
      


            }
              /* 
           
            // Assert.That(driver.Url.Contains(""))

            ;

            

           
            
            Thread.Sleep(2000);

            selectPage.BuyNowButtonClicked();
            Thread.Sleep(2000);
            selectPage.CloseButtonClicked();
            Thread.Sleep(2000);*/



        }
    }
}
