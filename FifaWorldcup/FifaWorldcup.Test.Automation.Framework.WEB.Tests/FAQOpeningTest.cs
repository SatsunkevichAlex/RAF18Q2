using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class FAQOpeningTest : BaseWebTest
    {
        [Test]
        public void FAQOpening()
        {
            HomeForm home = new HomeForm();
            Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
            home.Header.GoToSection("Fan zone");
            FanZoneForm fanZone = new FanZoneForm();
            Assert.AreEqual("Fan Zone".ToLower(), fanZone.Title.ToLower());
            FAQForm faqPage = fanZone.GoToFAQ();
            Assert.AreEqual("Frequently asked questions".ToLower(), faqPage.Title.ToLower());
            Assert.NotZero(faqPage.FAQTopics.Count);
        }
    }
}
