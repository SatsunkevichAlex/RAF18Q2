using FifaWorldcup.Test.Automation.Framework.CORE;
using NUnit.Framework;
using System.Configuration;
using System.Reflection;

namespace FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects
{
    public class BaseWebTest
    {
        protected static Browser browser;
        public Logger Log => new Logger(this.GetType());
        public TestContext TestContext { get; set; }

        [SetUp]
        public void InitTest()
        {
            Log.Info("Start executing test");
            browser = Browser.Instance;
            Browser.Maximise();
            Browser.NavigateTo(ConfigurationManager.AppSettings["StartUrl"]);
        }

        [TearDown]
        public void CleanTest()
        {
            Browser.Quit();
            Log.Info($"Test finished with <{TestContext.CurrentContext.Result.Outcome}> result! \n");
        }
    }
}