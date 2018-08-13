using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class StatisticsOfTheMatchPresentedtTest : BaseWebTest
    {
        [Test]
        public void StatisticsOfTheMatchPresented()
        {
            HomeForm homeForm = new HomeForm();
            Assert.IsTrue(homeForm.IsHomeFormTitleDisplayed);

            MatchesForm matchesForm = homeForm.GoToMatchesForm();
            Assert.IsTrue(matchesForm.IsMatchesPresented);

            const int countOfMatches = 16;
            MatchForm matchForm = matchesForm.OpenRandomMatch(new Random().Next(countOfMatches));
            Assert.IsTrue(matchForm.IsScorePresented);
            Assert.IsTrue(matchForm.IsLocationPresented);
            Assert.IsTrue(matchForm.IsDatePresented);
            Assert.IsTrue(matchForm.IsTeamsPresented);

            MatchStatisticsForm matchStatisticsForm = matchForm.GoToMatchStatistics();
            Assert.IsTrue(matchStatisticsForm.IsStatisticsPresented);
        }
    }
}