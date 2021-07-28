using AutomationFramework;
using FluentAssertions;
using Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Specs.Steps
{
    [Binding]
    public class ReqAPISteps
    {
        private string name;
        private string job;
        private int id;
        private IRestResponse response;
        private RestService _service;

        public string url { get; private set; }

        public ReqAPISteps()
        {
            url = ConfigBuilder.GetUrl("testApiUrl");
        }
        [Given(@"post request")]
        public void GivenPostRequest()
        {
            _service = new RestService(url, Method.POST);
            _service.BuildRequest("/api/users");
        }
        [Given(@"get request")]
        public void GivenGetRequest()
        {
            _service = new RestService(url, Method.GET);
            _service.BuildRequest($"/api/users/{id}");
        }

        [Given(@"user data: (.*) and (.*)")]
        public void GivenUserDataAnd(string name, string job)
        {
            this.name = name;
            this.job = job;
        }
        [Given(@"user (.*)")]
        public void GivenUserId(int id)
        {
            this.id = id;
        }
        [When(@"post user")]
        public void WhenPostUser()
        {
            _service.AddBody(new
            {
                name = this.name,
                job = this.job
            });
            response = _service.ExecuteRequest();
        }
        [When(@"I execute get request")]
        public void WhenIExecuteGetRequest()
        {
            response = _service.ExecuteRequest();
        }
        [When(@"I execute delete request")]
        public void WhenIExecuteDeleteRequest()
        {
            response = _service.ExecuteRequest();
        }

        [Then(@"I get correct response code (.*)")]
        public void ThenIGetCorrectData(int code)
        {
            response.StatusCode.Should().Be(code);
        }
        [Given(@"get delete request")]
        public void GivenGetDeleteRequest()
        {
            _service = new RestService(url, Method.DELETE);
            _service.BuildRequest($"/api/users/{id}");
        }


        [Then(@"I get correct data (.*) (.*) (.*)")]
        public void ThenGetCorrectResponse(string email, string first_name, string last_name)
        {
            response.StatusCode = System.Net.HttpStatusCode.OK;
            var responseData = new JsonSerializer().Deserialize<ResponseModel>(response);
            responseData.data.id.Should().Be(this.id);
            responseData.data.email.Should().Be(email);
            responseData.data.first_name.Should().Be(first_name);
            responseData.data.last_name.Should().Be(last_name) ;
        }
    }
}
