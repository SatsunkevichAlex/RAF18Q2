using System;
using FifaWorldcup.Test.Automation.Framework.CORE;
using FifaWorldcup.Test.Automation.Framework.API;

namespace Fifaworldcup.Test.Automation.Framework.API.Tests
{
    public class BaseAPITest
    {
        public Logger Log => new Logger(this.GetType());

        public FrameworkClient client = new FrameworkClientFactory()
        {
            BaseEndPont = new Uri("https://www.fifa.com")
        }
            .GetRestClient();
    }
}
