using FifaWorldcup.Test.Automation.Framework.API.Requests;
using FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers;
using RestSharp;
using System;

namespace FifaWorldcup.Test.Automation.Framework.API
{
    public class FrameworkClient
    {
        public FrameworkClient(RestClient client)
        {
            this.Client = client;

            this.Client.AddHandler("application/json", JSONDeSerializer.Instance);
            this.Client.AddHandler("text/json", JSONDeSerializer.Instance);
            this.Client.AddHandler("*+json", JSONDeSerializer.Instance);

            this.Client.AddHandler("application/xml", XMLDeSerializer.Instance);
            this.Client.AddHandler("text/xml", XMLDeSerializer.Instance);
            this.Client.AddHandler("*+xml", XMLDeSerializer.Instance);
            this.Client.AddHandler("@*@", XMLDeSerializer.Instance);
        }

        public RestClient Client { get; set; }

        public IRestResponse<T> ExecuteRequest<T>(CustomRequest request) where T : new()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restResponse = Client.Execute<T>(request.Build());

            return restResponse;
        }
    }
}
