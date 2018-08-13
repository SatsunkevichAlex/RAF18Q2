using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class InstagramRedirectTest : BaseWebTest
    {

        [Test]
        public void InstagramRedirect()
        {
            HomeForm home = new HomeForm();
            home.Header.GoToInstagram();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.GoToInstagram();
            Browser.SwitchToOpenedTab();
            expected = "https://www.instagram.com/fifaworldcup/";
            actual = Browser.Driver.Url;
            Assert.AreEqual(expected, actual);
        }
    }
}
