using System;
using System.Collections.Generic;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using NUnit.Framework;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class GroupScrollingTest : BaseWebTest
    {
        [Test]
        public void GroupScrolling()
        {
            HomeForm home = new HomeForm();
            Assert.AreEqual("2018 FIFA World Cup Russia™".ToLower(), home.Header.GetTitleText.ToLower());
            home.Header.GoToSection("Groups");
            GroupsForm groups = new GroupsForm();
            Assert.AreEqual(groups.Title.ToLower(), "Groups".ToLower());
            groups.ScrollToGroup("Group F");
            List<string> teamsNames = groups.TeamNames("Group F");
            Assert.IsTrue(groups.GroupIsDisplayed("Group F"));
            GroupAnalysisForm group =  groups.GoToGroup("Group F");
            List<string> teams = group.TeamsNames;
        }
    }
}
