using OpenQA.Selenium;
using System;

namespace PageObject
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
