using AutomationFramework;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
namespace Tests
{
    [Binding]
    public class BaseTestUI
    {
        protected static IWebDriver Driver { get; private set; }
        protected static DriverManager Manager { get; set; }
        private readonly ScenarioContext _scenarioContext;

        public BaseTestUI(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
      
        [BeforeScenario("Login")]
        public static void Setup()
        {
            //Manager = WebDriverFactory.GetManager(BrowserType.Chrome);
            Manager = WebDriverFactory.GetManager(BrowserType.RemoteChromeDriver);
            Driver = Manager.GetDriver();
        }

        [AfterScenario("Login")]
        public static void TearDown()
        {
            Manager.QuitDriver();
        }
    }
}
