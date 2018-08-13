using RestSharp;
using System;

namespace FifaWorldcup.Test.Automation.Framework.API
{
    public class FrameworkClientFactory
    {
        public Uri BaseEndPont { get; set; }

        public FrameworkClient GetRestClient()
        {
            var client = new RestClient(this.BaseEndPont);

            return new FrameworkClient(client);
        }
    }
}
