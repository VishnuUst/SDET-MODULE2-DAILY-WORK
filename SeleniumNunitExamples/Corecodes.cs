using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    internal class Corecodes
    {
        Dictionary<string, string> ? properties;
        public IWebDriver? driver;
        public void ReadConfiguration()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string,string>();
            string fileName = currDir + "/configursetting/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public bool CheckLinkSatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;

            }
           
        }
        [OneTimeSetUp] 
        public void Intializevrowser() 
        {
            ReadConfiguration();
            if (properties["browser"] .ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
