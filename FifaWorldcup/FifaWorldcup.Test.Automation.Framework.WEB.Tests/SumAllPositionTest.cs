using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class SumAllPositionTest : BaseWebTest
    {
        [Test]
        public void CorrectAddUp()
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
            Assert.IsTrue(playerBrowser.IsCorrect);
        }
    }
}
