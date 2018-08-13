using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class LogoIsDisplayTest : BaseWebTest
    {
        private const int NUMBER_All_PLAYERS = 736;
        private const int NUMBER_OF_MATCHES = 3;

        [Test]
        public void LogoIsDisplay()
        {
            HomeForm home = new HomeForm();
            Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
            home.GoToPlayersForm();

            PlayersForm players = new PlayersForm();
            players.WaitForLoadingPage();
            Assert.IsTrue(players.IsFormTitleDisplay);

            PlayerBrowserSearchByPositionForm playerBrowser = players.SelectPlayer();
            playerBrowser.WaitForLoadingPage();
            Assert.IsTrue(playerBrowser.IsFormTitleDisplay);

            PlayerForm player = playerBrowser.GetInfo(new Random().Next(NUMBER_All_PLAYERS));
            player.WaitForLoadingPage();
            Assert.IsTrue(player.IsFormTitleDisplay);
            MatchSummaryForm matchSummary = player.SelectMatch(new Random().Next(NUMBER_OF_MATCHES));
            Assert.IsTrue(matchSummary.IsFormTitleDisplay);

            MatchForm match = matchSummary.GoToMatchForm();
            match.WaitForLoadingPage();
            Assert.IsTrue(match.IsFormTitleDisplay);
            Assert.IsTrue(match.IsLogoPresented);
        }
    }
}
