using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace AutomationFramework
{
    internal class FireFoxDriverManager : DriverManager
    {
        private FirefoxDriverService service;
        protected override void CreateDriver()
        {
            var options = new FirefoxOptions();
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
