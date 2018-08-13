using System.Linq;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class PlayerBrowserSearchByTeamForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        public ElementsList Teams => Has<ElementsList>(By.XPath("//span[@class='fi-t__nText ']"));
        private ElementsList teamCountry => Has<ElementsList>(By.XPath("//div[@id = 'team-players-by-team']//div[@class = 'fi-p__country']"));

        public PlayerBrowserSearchByTeamForm() : base(form.Locator)
        { }

        public void ClickTeam(string teamName)
        {
            Log.Info($"Click on {teamName} team");
            Teams.JSClickElement(teamName);
        }

        public bool SelectedTeamIsDisplayed(string teamName)
        {
            Log.Info("Check is selected team displayed");

            bool response = true;
            foreach (var playerCountry in teamCountry.Elements.Select(t => t.Text.ToLower()))
            {
                if (playerCountry != teamName.ToLower())
                {
                    response = false;
                    break;
                }
            }
            return response;
        }

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}
