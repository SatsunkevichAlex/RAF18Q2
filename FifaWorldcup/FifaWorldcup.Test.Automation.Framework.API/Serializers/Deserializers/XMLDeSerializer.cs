using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    public class XMLDeSerializer : IDeserializer
    {
        public static IDeserializer Instance { get; private set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content.ToString();
            StringReader stringReader = new StringReader(content);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
    }
}