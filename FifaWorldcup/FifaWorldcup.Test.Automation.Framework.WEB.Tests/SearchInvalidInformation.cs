using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class SearchInvalidnformationTest : BaseWebTest
    {
        [Test]
        public void SearchInvalidInformation()
        {
            HomeForm home = new HomeForm();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.OpenSearchLine();
            SearchForm search = new SearchForm();
            bool news = search.Search("epam");
            Assert.AreEqual(news, false);
        }
    }
}
