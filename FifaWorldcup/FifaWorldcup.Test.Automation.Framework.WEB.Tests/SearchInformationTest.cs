using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class SearchInformationTest : BaseWebTest
    {
        [Test]
        public void SearchValidInformation()
        {
            HomeForm home = new HomeForm();
            string expected = "2018 FIFA World Cup Russia™";
            string actual = home.Header.GetTitleText;
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            home.Header.OpenSearchLine();
            SearchForm search = new SearchForm();
            bool news = search.Search("modric");
            Assert.AreEqual(news,true);
        }
    }
}
