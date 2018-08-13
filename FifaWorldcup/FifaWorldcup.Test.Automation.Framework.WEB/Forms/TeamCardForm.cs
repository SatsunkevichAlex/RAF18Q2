using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TeamCardForm : BaseForm
    {
        static LabelText Image = new LabelText(By.XPath("//img[@class='img-responsive lazyloaded']"));
        static LabelText flag = new LabelText(By.XPath("//div[@class='fi-team-card__flag']"));
        static LabelText TeamName = new LabelText(By.XPath("//div[@class='fi-team-card__name']"));
        private Button Team;

        public TeamCardForm(By locator) : base(locator)
        {
            Team = new Button(locator);
        }

        public List<string> GetCountryTeamLineup()
        {
            Log.Info("Get team lineup");
            Team.Click();
            TeamForm team = new TeamForm();
            List<string> lineup = new List<string>();
            lineup = team.GetTeamLineup();
            return lineup;
        }
    }
}