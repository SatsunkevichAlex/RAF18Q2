using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class ScoreOfMatchPresentedTest : BaseWebTest
    {
        [Test]
        public void ScoreOfMatchPresented()
        {
            HomeForm homeForm = new HomeForm();
            Assert.IsTrue(homeForm.IsHomeFormTitleDisplayed);
            MatchesForm matchesForm = homeForm.GoToMatchesForm();
            Assert.IsTrue(matchesForm.IsFormTitleDisplayed);
            Assert.IsTrue(matchesForm.IsScorePresented);
        }
    }
}
