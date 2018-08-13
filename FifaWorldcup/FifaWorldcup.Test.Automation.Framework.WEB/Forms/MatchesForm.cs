using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class MatchesForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//div[@class='fi-boxed-page']"));
        LabelText scorOfMatch = new LabelText(By.XPath("//span[@class='fi-s__scoreText']"));
        ElementsList matches = new ElementsList(By.XPath("//div[@id='fi-list-view']//div[@class='fi-mu result']/."));
        LabelText formTitle = new LabelText(By.XPath("//h1[text()='Matches']"));

        public MatchesForm() : base(form.Locator)
        { }

        public bool IsScorePresented => scorOfMatch.FindElements(scorOfMatch.Locator).All(scorOfMatch => scorOfMatch.Text != null || scorOfMatch.Text == string.Empty);

        public MatchForm OpenRandomMatch(int randomNumberMatch)
        {
            Log.Info("Open random match");
            matches.JSClickElement(randomNumberMatch);
            return new MatchForm();
        }

        public bool IsFormTitleDisplayed => Browser.Instance.GetFormTitle != null;

        public bool IsMatchesPresented => matches != null;
    }
}