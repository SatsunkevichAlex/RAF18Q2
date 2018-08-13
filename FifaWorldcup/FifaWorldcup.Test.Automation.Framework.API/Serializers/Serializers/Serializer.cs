using RestSharp;
using RestSharp.Serializers;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    class Serializer
    {
        private DataFormat dataFormat { get; set; }

        public Serializer(DataFormat format)
        {
            dataFormat = format;
        }

        public string Serialize(object obj)
        {
            return GetSerializer.Serialize(obj);
        }

        public ISerializer GetSerializer
        {
            get
            {
                if (dataFormat == DataFormat.Json)
                {
                    return JSONSerializer.Instance;
                }
                else
                {
                    return XMLSerializer.Instance;
                }
            }
        }
    }
}
