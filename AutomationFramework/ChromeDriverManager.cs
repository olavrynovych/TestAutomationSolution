using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace AutomationFramework
{
    internal class ChromeDriverManager : DriverManager
    {
        private ChromeDriverService service;
        protected override void CreateDriver()
        {
            var options = new ChromeOptions();
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
