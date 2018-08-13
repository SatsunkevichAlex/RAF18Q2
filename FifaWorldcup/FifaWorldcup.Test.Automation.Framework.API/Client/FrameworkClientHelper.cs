namespace FifaWorldcup.Test.Automation.Framework.API
{
    public static class FrameworkClientHelper
    {
        public static FrameworkClient ClentForms => new FrameworkClientFactory
        {
            BaseEndPont = ServiceConfig.ApplicationEndPointForms
        }
            .GetRestClient();

        public static FrameworkClient ClientFields => new FrameworkClientFactory
        {
            BaseEndPont = ServiceConfig.ApplicationEndPointFields
        }
            .GetRestClient();
    }
}
