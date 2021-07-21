using FluentAssertions;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Tests;

namespace SpecFlowProject.Specs.Features
{
    [Binding]
    public class SpecFlowFeature1Steps : BaseTest
    {
        [Given(@"")]
        public void Given()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Thread.Sleep(2000);
        }
        
        [When(@"")]
        public void When()
        {
            Driver.Url.Should().Be("https://www.saucedemo.com");
        }
    }
}
