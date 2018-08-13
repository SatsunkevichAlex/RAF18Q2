using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class CoachCountryIsDisplayTest : BaseWebTest
    {
        private const int NUMBER_OF_COACHES = 32;

        [Test]
        public void IsCountryDisplay()
        {
            HomeForm home = new HomeForm();
            Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
            home.GoToPlayersForm();

            PlayersForm players = new PlayersForm();
            players.WaitForLoadingPage();
            Assert.IsTrue(players.IsFormTitleDisplay);

            CoachesForm coaches = players.SelectCoach();
            coaches.WaitForLoadingPage();
            Assert.IsTrue(coaches.IsFormTitleDisplay);

            CoachForm coach = coaches.GoToCoachForm(new Random().Next(NUMBER_OF_COACHES));
            coach.WaitForLoadingPage();
            Assert.IsTrue(coach.IsFormTitleDisplay);
            Assert.IsTrue(coach.IsDisplay);
        }
    }
}
