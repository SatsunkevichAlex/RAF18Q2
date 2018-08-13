using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class TeamIsDisplayTest : BaseWebTest
    {
        private const string TEAM_NAME = "Brazil";

        [Test]
        public void TeamIsDisplay()
        {
            try
            {
                HomeForm home = new HomeForm();
                Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
                home.GoToPlayersForm();

                PlayersForm players = new PlayersForm();
                players.WaitForLoadingPage();
                Assert.IsTrue(players.IsFormTitleDisplay);

                PlayerBrowserSearchByPositionForm playerBrowser = players.SelectPlayer();
                PlayerBrowserSearchByTeamForm playerBrowserTeam = playerBrowser.SelectTeam();
                playerBrowserTeam.WaitForLoadingPage();
                Assert.IsTrue(playerBrowserTeam.IsFormTitleDisplay);
                playerBrowserTeam.ClickTeam(TEAM_NAME);
                playerBrowserTeam.WaitForLoadingPage();
                Assert.IsTrue(playerBrowserTeam.SelectedTeamIsDisplayed(TEAM_NAME));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                ScreenshotTaker taker = new ScreenshotTaker();
                taker.MakeScreen();
                taker.PrintScreenshotsTo();
                Assert.Fail();
            }
        }
    }
}
