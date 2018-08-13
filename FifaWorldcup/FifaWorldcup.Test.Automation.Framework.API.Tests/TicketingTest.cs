using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;
using RestSharp;

namespace Fifaworldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    public class TicketingTest : BaseAPITest
    {
        [Test]
        public void Ticketing()
        {
            Log.Info("Ticketing request test");

            IRestResponse responseWorlCup = client.ExecuteRequest<CustomRequest>(new CustomRequest().WithResource("/worldcup"));
            IRestResponse responseOrganization = client.ExecuteRequest<CustomRequest>(new CustomRequest().WithResource("/worldcup/organisation/"));
            IRestResponse responseTicketing = client.ExecuteRequest<CustomRequest>(new CustomRequest().WithResource("/worldcup/organisation/ticketing/"));

            Assert.AreEqual(System.Net.HttpStatusCode.OK, responseWorlCup.StatusCode);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, responseOrganization.StatusCode);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, responseTicketing.StatusCode);
        }
    }
}
