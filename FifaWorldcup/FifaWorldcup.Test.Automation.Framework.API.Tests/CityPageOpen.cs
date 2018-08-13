using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    class CityPageOpen
    {
        [Test]
        public void CityPageOpenTest()
        {
            FrameworkClient client = new FrameworkClientFactory()
            {
                BaseEndPont = new System.Uri("https://www.fifa.com/")
            }.GetRestClient();
            CustomRequest request = new CustomRequest()
                .WithResource("/worldcup/destination/cities/city=35122/")
                .WithMethod(RestSharp.Method.GET);
            RestSharp.IRestResponse response = client.ExecuteRequest<CustomRequest>(new CustomRequest()
                .WithResource("/worldcup/destination/cities/city=35122/")
                .WithMethod(RestSharp.Method.GET)
                );
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(response.Content);
        }
    }
}
