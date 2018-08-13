using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class ChangingLanguageTest : BaseWebTest
    {
        [Test]
        public void ChangingLanguage()
        {
            HomeForm home = new HomeForm();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.OpenLanguageList();

            LanguagePopupForm languageForm = new LanguagePopupForm();
            languageForm.ChangeLanguage("Русский");
            actual = home.Header.GetTitleText;
            expected = "Чемпионат мира по футболу FIFA 2018 в России™";
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
        }
    }
}