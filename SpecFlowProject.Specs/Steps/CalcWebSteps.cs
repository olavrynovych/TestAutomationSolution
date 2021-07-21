using FluentAssertions;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Tests;

namespace SpecFlowProject.Specs.Steps
{
    [Binding]
    public class CalcWebSteps : BaseTest
    {
        [Given(@"Web driver")]
        public void GivenWebDriver()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Thread.Sleep(2000);
        }
        
        [When(@"I go to website")]
        public void WhenIGoToWebsite()
        {
            Driver.Url.Should().Be("https://www.saucedemo.com");
        }
    }
}
