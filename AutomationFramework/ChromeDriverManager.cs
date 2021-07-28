using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace AutomationFramework
{
    internal class ChromeDriverManager : DriverManager
    {
        private ChromeDriverService service;
        protected override void CreateDriver(bool remoteDriver, string remoteUrl)
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-dev-shm-usage");

            if (remoteDriver)
                driver = new RemoteWebDriver(new Uri(remoteUrl), options);
            else
                driver = new ChromeDriver(service, options);
        }

        protected override void StartService()
        {
            service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        protected override void StopService()
        {
            if (service != null && service.IsRunning)
            {
                service.Dispose();
            }
        }
    }
}
