using RestSharp;
using RestSharp.Deserializers;

namespace FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers
{
    class Deserializer : IDeserializer
    {
        private DataFormat dataFormat;

        public Deserializer(DataFormat format)
        {
            dataFormat = format;
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public IDeserializer GetDeSerializer
        {
            get
            {
                if (dataFormat == DataFormat.Json)
                {
                    return JSONDeSerializer.Instance;
                }
                else
                {
                    return XMLDeSerializer.Instance;
                }
            }
        }

        public T Deserialize<T>(IRestResponse response)
        {
            return GetDeSerializer.Deserialize<T>(response);
        }
    }
}
