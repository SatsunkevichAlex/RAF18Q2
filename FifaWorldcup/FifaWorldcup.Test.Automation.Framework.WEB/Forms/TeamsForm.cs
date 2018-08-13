using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TeamsForm : BaseForm
    {
        static LabelText _title = new LabelText(By.XPath("//h1[@class='fi-pageheader__title']"));
        public ElementsList teams => Has<ElementsList>(By.XPath("//a[@class='fi-team-card fi-team-card__team']"));

        public TeamsForm() : base(By.XPath("//div[@class='fi-boxed-page']//div[@class='row']"))
        { }

        public List<string> Getteamlineup(string country)
        {
            Log.Info($"Get {country} lineup");
            List<string> lineup = new List<string>();
            foreach (string team in teams.Elements.Select(t => t.Text))
            {
                if (team == country)
                {
                    (teams.Elements.FirstOrDefault(t => t.Text == team)).Click();
                    lineup = (new TeamForm()).GetTeamLineup();
                }
            }
            return lineup;
        }

        public int TeamsNumber => teams.Count;

        public new string Title => _title.Text;

        public TeamForm GoToTeam(int n)
        {
            Log.Info("Open team form");
            Wait.Until(ExpectedConditions.ElementToBeClickable(teams[n])).Click();
            return new TeamForm();
        }
    }
}
