using Fifaworldcup.Test.Automation.Framework.API.Tests;
using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;
using RestSharp;
using System.Net;


namespace FifaWorldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    public class InvalidPlayerRequestTest : BaseAPITest
    {
        [Test]
        public void InvalidPlayerRequest()
        {
            const string invalidPlayerResours = "/worldcup/players/player/4007212121/";

            Log.Info("Invalid player request test");
            
            IRestResponse response = client.ExecuteRequest<CustomRequest>(new CustomRequest().WithResource(invalidPlayerResours));

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
