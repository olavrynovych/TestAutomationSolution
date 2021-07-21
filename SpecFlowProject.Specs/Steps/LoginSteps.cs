using AutomationFramework;
using FluentAssertions;
using OpenQA.Selenium;
using PageObject;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;
using Tests;

namespace SpecFlowProject.Specs.Features
{
    [Binding]
    public class LoginSteps : BaseTestUI
    {
        private string url { get; set; }

        private string name { get; set; }
        private string pass { get; set; }
        public LoginPage LoginPage { get; private set; }


        public LoginSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            url = ConfigurationManager.AppSettings["testUiUrl"];
        }

        [Given(@"website")]
        public void GivenWebsite()
        {
            Driver.Navigate().GoToUrl(url);
            LoginPage = new LoginPage(Driver);
        }
        
        [Given(@"login and password (.*) (.*)")]
        public void GivenLoginAndPassword(string username, string pass)
        {
            this.name = username;
            this.pass = pass;
        }
        
        [When(@"login with params")]
        public void WhenLoginWithParams()
        {
            LoginPage.SetLogin(name);
            LoginPage.SetPassword(pass);
            LoginPage.ClickLogin();
        }
        
        [Then(@"login is successfull url is ccorrect (.*)")]
        public void ThenLoginIsSuccessfullUrlIsCcorrect(string url)
        {
            Driver.Url.Should().Be(url);
        }
    }
}
