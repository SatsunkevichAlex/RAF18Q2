using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class PlayerBirthIsDisplayTest : BaseWebTest
    {
        private const int NUMBER_ALL_PLAYERS = 736;

        [Test]
        public void IsBirthDisplay()
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

            PlayerForm player = playerBrowser.GetInfo(new Random().Next(NUMBER_ALL_PLAYERS));
            player.WaitForLoadingPage();
            Assert.IsTrue(player.IsFormTitleDisplay);
            Assert.IsTrue(player.IsDisplay);
        }
    }
}
