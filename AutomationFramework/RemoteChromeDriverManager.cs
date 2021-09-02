using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace AutomationFramework
{
    class RemoteChromeDriverManager : DriverManager
    {
        protected override void CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-dev-shm-usage");
            var url = ConfigurationManager.AppSettings["dockerUrl"];

            driver = new RemoteWebDriver(new Uri(url), options);
        }

        protected override void StartService()
        {
        }

        protected override void StopService()
        {
          
        }
    }
}
