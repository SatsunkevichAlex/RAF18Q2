using System;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class TeamProfileRedirectingTest : BaseWebTest
    { 

        [Test]
        public void TeamProfileRedirecting()
        {
            HomeForm home = new HomeForm();
            Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
            home.Header.GoToSection("teams");
            TeamsForm teams = new TeamsForm();
            Assert.AreEqual(32, teams.TeamsNumber);
            Assert.AreEqual("Teams".ToLower(), teams.Title.ToLower());
            TeamForm selectedTeam = teams.GoToTeam(new Random().Next(31));
            string teamName = selectedTeam.Title;
            TeamProfileForm teamProfile = selectedTeam.GoToTeamProfile();
            Assert.AreEqual(teamName, teamProfile.TeamName);
            Assert.IsTrue(teamProfile.TeamNameIsDisplayed);
            Assert.IsTrue(Browser.Url.Contains(teamName.ToLower()));
        }
    }
}
