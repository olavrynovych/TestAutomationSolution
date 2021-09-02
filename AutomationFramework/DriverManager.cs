using OpenQA.Selenium;

namespace AutomationFramework
{
    public abstract class DriverManager
    {
        protected IWebDriver driver;
        protected abstract void CreateDriver(bool remoteDriver, string remoteUrl);
        protected abstract void StartService();
        protected abstract void StopService();


        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public IWebDriver GetDriver(bool remoteDriver, string url)
        {
            if (driver == null)
            {
                StartService();
                CreateDriver(remoteDriver, url);
            }

            return driver;
        }
    }
}
