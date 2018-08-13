using System;
using FifaWorldcup.Test.Automation.Framework.API.Requests;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.API.Tests
{
    [TestFixture]
    public class Login
    {
        [Test]
        public void LoginTest()
        {
            FrameworkClient client = new FrameworkClientFactory()
            {
                BaseEndPont = new Uri("https://account.fifa.com")
            }.GetRestClient();

            var request = new CustomRequest()
                .WithResource("5a7baeb7-e706-4830-ad9f-103eba126311/B2C_1A_FIFA_SignUpOrSignIn/SelfAsserted?tx=StateProperties=eyJUSUQiOiI1ZjNkZTBkNy1lMDI1LTRiZjQtYmEyMi1jZTgyNTAxNjhmMjgifQ&p=B2C_1A_FIFA_SignUpOrSignIn")
                .WithMethod(RestSharp.Method.POST)
                .WithHeader("X-CSRF-TOKEN", "Rll0SDgvZEtYZ2FydmZrcHI5QVcxSTcvVkNIUlNPZldlMC9YdGFyQ3paU1Jia3d2MTlTT2s1M1dMVjdzMzUxMC93bnFUQnRQNXpzazdpL2Z3WDQvS0E9PTsyMDE4LTA4LTEyVDA4OjE3OjUyLjAyNDgzNlo7L2xsM1ptZitFbTZLVDVoVDhKOEpTdz09O3siT3JjaGVzdHJhdGlvblN0ZXAiOjF9")
                .WithCookie("x-ms-cpim-trans", "eyJUX0RJQyI6W3siSSI6IjVmM2RlMGQ3LWUwMjUtNGJmNC1iYTIyLWNlODI1MDE2OGYyOCIsIlQiOiJmZHByZGFhZGZhbnMub25taWNyb3NvZnQuY29tIiwiUCI6ImIyY18xYV9maWZhX3NpZ251cG9yc2lnbmluIiwiQyI6IjY0ZTlhZmE4LWM1YzAtNDEzZC04ODJiLWJjOWU2YTgxZTI2NCIsIlMiOjMsIk0iOnt9LCJEIjowfV0sIkNfSUQiOiI1ZjNkZTBkNy1lMDI1LTRiZjQtYmEyMi1jZTgyNTAxNjhmMjgifQ==")
                .WithBody("request_type=RESPONSE&signInName=atlabtestemail%40mail.ru&password=2lVyjYxxXks5K");
            RestSharp.IRestResponse response = client.ExecuteRequest<CustomRequest>(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.NotNull(response.Content);
        }
    }
}

