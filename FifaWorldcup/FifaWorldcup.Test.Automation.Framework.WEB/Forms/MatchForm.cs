using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class MatchForm : BaseForm
	{
        static LabelText Form => new LabelText(By.XPath("//h1"));
        private LabelText Score => new LabelText(By.XPath("(//span[@class='fi-s__scoreText'])[1]"));
        private LabelText Location => new LabelText(By.XPath("//div[@class='fi__info__location']"));
        private LabelText Date => new LabelText(By.XPath("//div[@class='fi-mu__info__datetime']"));
        private LabelText Team => new LabelText(By.XPath("//div[@class='fi-mh result']//span[@class='fi-t__nText ']"));
        private LabelText Logo => new LabelText(By.XPath("//div[@class='fi-mh result']"));
        private ElementsList MatchInfoTabs => new ElementsList(By.XPath("//div[@class='tabs-nav__content']/*[@class='tab-item']"));
        private Button ManOfTheMatchSectionButton => new Button(By.XPath("//a[contains(@href, 'motm')]/parent::*"));

        public LabelText ManOfTheMatch => Has<LabelText>(By.XPath("//*[@id='motm']//div[@class='fi-motm--promo__winner']//div[@class='fi-p__name']"));

        public MatchForm() : base(Form.Locator)
		{ }
		
        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;

        public bool IsScorePresented => Score.Displayed;

        public bool IsLocationPresented => Location.Displayed;

        public bool IsDatePresented => Date.Displayed;

        public bool IsLogoPresented => Logo.Displayed;

        public bool IsTeamsPresented => Team.FindElements(Team.Locator).All(t => t != null);

        public MatchStatisticsForm GoToMatchStatistics()
        {
            Log.Info("Open match statistics form");
            MatchInfoTabs.ClickElement("Statistics");
            return new MatchStatisticsForm();
        }

        public void GoToManOfTheMatchPage()
        {
            Log.Info("Open man of the match form");
            ManOfTheMatchSectionButton.JsClick();
        }
    }
}