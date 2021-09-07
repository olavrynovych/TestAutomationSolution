using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Reflection;
using Tests;

namespace SpecFlowProject.Specs
{
    public class ConfigBuilder
    {
        public static readonly IConfigurationRoot Builder;
        public static bool IsRemote 
        { 
            get
            { 
                return bool.Parse(Builder.GetSection("UseDocker").Value); 
            } 
        }

        static ConfigBuilder()
        {
            Builder = new ConfigurationBuilder().AddJsonFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"appsettings.json")).Build();
        }

        public static string GetUrl(string urlName) 
        {
            return Builder.GetSection("Urls")[urlName];
        }
        public static BrowserType GetBrowser()
        {
            var browserType = Builder.GetSection("BrowserType").Value;
            switch (browserType)
            {
                case "Chrome":
                        return BrowserType.Chrome;
                case "FireFox":
                        return BrowserType.FireFox;
                default:
                    throw new NotImplementedException($"There is no implementation for such browser '{browserType}'.");
            }
        }
    }
}
