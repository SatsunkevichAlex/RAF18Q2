using FifaWorldcup.Test.Automation.Framework.API.Serializers.Serializers;
using RestSharp;

namespace FifaWorldcup.Test.Automation.Framework.API.Requests
{
    public class CustomRequest
    {
        public RestRequest _request { get; private set; }
        private DataFormat dataFormat;

        public CustomRequest()
        {
            this._request = new RestRequest()
            {
                JsonSerializer = JSONSerializer.Instance,
                XmlSerializer = XMLSerializer.Instance
            };
        }

        public DataFormat DataFormat
        {
            get
            {
                return dataFormat;
            }
            set
            {
                dataFormat = value;
            }
        }

        public IRestRequest Build() => this._request;

        public CustomRequest WithResource(string Resource)
        {
            _request.Resource = Resource;
            return this;
        }

        public CustomRequest WithHeader(string hName, string hValue)
        {
            _request.AddHeader(hName, hValue);
            return this;
        }

        public CustomRequest WithMethod(Method method)
        {
            _request.Method = method;
            return this;
        }

        public CustomRequest WithFile(string fName, string fPath)
        {
            _request.AddFile(fName, fPath);
            return this;
        }

        public CustomRequest WithFile(string name, byte[] binaryFile, string fName)
        {
            _request.AddFile(name, binaryFile, fName);
            return this;
        }

        public CustomRequest WithXml(object xmlObj)
        {
            _request.AddXmlBody(xmlObj);
            return this;
        }

        public CustomRequest WithJson(object jsonObj)
        {
            _request.AddJsonBody(jsonObj);
            return this;
        }

        public CustomRequest WithUrlSegment(string urlName, string urlSegment)
        {
            _request.AddUrlSegment(urlName, urlSegment);
            return this;
        }

        public CustomRequest WithParameter(string name, object value)
        {
            _request.AddParameter(name, value);
            return this;
        }

        public CustomRequest WithParameter(string name, object value, ParameterType type)
        {
            _request.AddParameter(name, value, type);
            return this;
        }

        public CustomRequest WithParameter(string name, object value, string contentType, ParameterType type)
        {
            _request.AddParameter(name, value, contentType, type);
            return this;
        }

        public CustomRequest WithParameterOrUpdate(string name, object value)
        {
            _request.AddOrUpdateParameter(name, value);
            return this;
        }

        public CustomRequest WithCookie(string name, string value)
        {
            _request.AddCookie(name, value);
            return this;
        }

        public CustomRequest WithBody(string body)
        {
            var contentType = _request.XmlSerializer.ContentType;
            if (this.DataFormat == DataFormat.Json)
            {
                contentType = _request.JsonSerializer.ContentType;
            }
            else
            {
                contentType = _request.XmlSerializer.ContentType;
            }
            _request.AddParameter(contentType, body, ParameterType.RequestBody);
            return this;
        }
    }
}
