using System;
using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    public class SearchWithValidData
    {
        [Test]
        public void SearchWithValidDataTest()
        {
            FrameworkClient client = new FrameworkClientFactory()
            {
                BaseEndPont = new Uri("https://www.fifa.com")
            }
            .GetRestClient();
            RestSharp.IRestResponse response = client.ExecuteRequest<CustomRequest>(new CustomRequest()
                .WithMethod(RestSharp.Method.GET)
                .WithResource("/search/")
                .WithParameter("q", "qwertmbvdjhcksabv")
                );
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            response = client.ExecuteRequest<CustomRequest>(new CustomRequest()
                .WithMethod(RestSharp.Method.GET)
                .WithResource("/search/page/1")
                .WithParameter("resultType", "generic")
                .WithParameter("q", "qwertmbvdjhcksabv")
                );
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsTrue(response.Content.Contains("No data available for specified filters"));
            Assert.NotNull(response.Content);
        }
    }
}