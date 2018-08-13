using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RestSharp;
using RestSharp.Serializers;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    public class XMLSerializer : ISerializer
    {
        private static XMLSerializer innerObject;
        public static XMLSerializer Instance => innerObject ?? (innerObject = new XMLSerializer());

        public XMLSerializer()
        {
            this.ContentType = "application/xml";
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }

        public string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Argument can't be null");
            }
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(nameof(obj));
                return serializer.Serialize(obj).ToString();
            };
        }
    }
}
