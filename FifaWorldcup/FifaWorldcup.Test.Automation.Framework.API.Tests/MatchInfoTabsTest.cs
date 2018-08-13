using Fifaworldcup.Test.Automation.Framework.API.Tests;
using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Fifaworldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    public class MatchInfoTabsTest : BaseAPITest
    {
        [Test]
        public void MatchInfoTabs()
        {
            Log.Info("Match info tabs test");

            //IRestResponse response = client.ExecuteRequest<CustomRequest>(new CustomRequest().WithResource);
        }
    }
}
