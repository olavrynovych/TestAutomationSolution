using AutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace Tests
{
    public class WebDriverFactory
    {
        public static DriverManager GetManager(BrowserType browserType)
        {
            DriverManager Manager;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    Manager = new ChromeDriverManager();
                    break;
                case BrowserType.FireFox:
                    Manager = new FireFoxDriverManager();
                    break;
                case BrowserType.Opera:
                default:
                    throw new ArgumentOutOfRangeException($"Driver is not implemented for '{browserType}'.");
            }

            return Manager;
        }
    }
}