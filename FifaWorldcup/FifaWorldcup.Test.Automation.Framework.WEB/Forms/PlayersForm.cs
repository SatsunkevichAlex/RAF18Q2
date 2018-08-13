using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class PlayersForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        private Button playerBrowserButton => Has<Button>(By.XPath("//span[text() = 'Player Browser']/parent::*"));
        private Button allCoachesButton => Has<Button>(By.XPath("//span[text() = 'All Coaches']/parent::*"));

        public PlayersForm() : base(form.Locator)
        { }

        public PlayerBrowserSearchByPositionForm SelectPlayer()
        {
            Log.Info("Select player");
            playerBrowserButton.Click();
            return new PlayerBrowserSearchByPositionForm();
        }

        public CoachesForm SelectCoach()
        {
            Log.Info("Select coach");
            allCoachesButton.JsClick();
            return new CoachesForm();
        }

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}