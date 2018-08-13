using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class FacebookRedirectTest : BaseWebTest
    {

        [Test]
        public void FacebookRedirect()
        {
            HomeForm home = new HomeForm();
            home.Header.GoToFacebook();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.GoToFacebook();
            Browser.SwitchToOpenedTab();
            expected = "https://www.facebook.com/fifaworldcup";
            actual = Browser.Driver.Url;
            Assert.AreEqual(expected, actual);
        }
    }
}
