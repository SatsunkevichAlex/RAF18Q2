using System;
using System.Configuration;

namespace FifaWorldcup.Test.Automation.Framework.API
{
    public static class ServiceConfig
    {
        private const string EndPointFormsKey = "EndPointForms";

        private const string EndPointFieldsKey = "EndPointFields";

        public static Uri ApplicationEndPointForms => new Uri(ConfigurationManager.AppSettings[EndPointFormsKey]);

        public static Uri ApplicationEndPointFields => new Uri(ConfigurationManager.AppSettings[EndPointFieldsKey]);
    }
}
