using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
	[TestFixture]
	public class TwitterRedirectTest : BaseWebTest
	{

		[Test]
        public void TwitterRedirect()
		{
			HomeForm home = new HomeForm();
            home.Header.GoToTwitter();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.GoToTwitter();
            Browser.SwitchToOpenedTab();
            expected = "https://twitter.com/FifaWorldCup";
            actual = Browser.Driver.Url;
            Assert.AreEqual(expected, actual);
        }
	}
}
