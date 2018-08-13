using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.IO;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    public class JSONDeSerializer : IDeserializer
    {
        public static IDeserializer Instance { get; private set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        private Newtonsoft.Json.JsonSerializer _serializer;

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content.ToString();
            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }
    }
}