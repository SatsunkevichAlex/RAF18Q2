using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class TeamLineUpTest : BaseWebTest
    {
        [Test]
        [Category("Positive")]
        public void TeamLineUpIsPresented()
        {
            HomeForm homeForm = new HomeForm();
            Assert.AreEqual(homeForm.IsHomeFormTitleDisplayed, true);
            homeForm.Header.GoToSection("teams");
            TeamsForm teams = new TeamsForm();
            teams.GoToTeam(1);
            TeamForm teamForm = new TeamForm();
            Assert.AreEqual(teamForm.IsTeamLineupPresented(), true);
        }
    }
}
