using System;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class ManOfTheMatchTest : BaseWebTest
    {
        [Test]
        public void ManOfTheMatch()
        {
            try
            {
                HomeForm home = new HomeForm();
                Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
                home.Header.GoToSection("teams");
                TeamsForm teams = new TeamsForm();
                Assert.AreEqual(32, teams.TeamsNumber);
                Assert.AreEqual("Teams".ToLower(), teams.Title.ToLower());
                TeamForm selectedTeam = teams.GoToTeam((new Random()).Next(teams.TeamsNumber - 1));
                MatchForm match = selectedTeam.GoToMatch((new Random()).Next(selectedTeam.Matches.Count - 1));
                match.GoToManOfTheMatchPage();
                Assert.IsTrue(match.ManOfTheMatch.Displayed);
            }
            catch
            {
                ScreenshotTaker screenshotmaker = new ScreenshotTaker();
                screenshotmaker.MakeScreen();
                screenshotmaker.PrintScreenshotsTo();
            }
        }
    }
}
