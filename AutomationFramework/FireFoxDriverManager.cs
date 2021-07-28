using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace AutomationFramework
{
    internal class FireFoxDriverManager : DriverManager
    {
        private FirefoxDriverService service;
        protected override void CreateDriver(bool remoteDriver, string remoteUrl)
        {
            var options = new FirefoxOptions();
            if (remoteDriver)
                driver = new RemoteWebDriver(new Uri(remoteUrl), options);
            else
                driver = new FirefoxDriver(service, options);
        }

        protected override void StartService()
        {
            service = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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
