using OpenQA.Selenium;

namespace AutomationFramework
{
    public abstract class DriverManager
    {
        protected IWebDriver driver;
        protected abstract void CreateDriver();
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

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                StartService();
                CreateDriver();
            }

            return driver;
        }
    }
}
