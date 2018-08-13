using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    public class JSONSerializer : ISerializer
    {
        private static JSONSerializer innerObject;
        public static JSONSerializer Instance => innerObject ?? (innerObject = new JSONSerializer());

        private Newtonsoft.Json.JsonSerializer _serializer;

        private JSONSerializer()
        {
            this.ContentType = "application/json";
            this._serializer = new Newtonsoft.Json.JsonSerializer
            {   
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
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
                var JsonTextWrite = new JsonTextWriter(writer)
                {
                    Formatting = Formatting.Indented,
                    QuoteChar = '"'
                };
                this._serializer.Serialize(JsonTextWrite, obj);
                return writer.ToString();
            };
        }
    }
}
