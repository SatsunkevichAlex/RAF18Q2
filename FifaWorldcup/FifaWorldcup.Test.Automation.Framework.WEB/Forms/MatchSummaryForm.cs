using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class MatchSummaryForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        private Button manOftheMatchButton => Has<Button>(By.XPath("//*[@href = '#motm']"));

        public MatchSummaryForm() : base(form.Locator)
        { }

        public MatchForm GoToMatchForm()
        {
            Log.Info("Go to match form");
            manOftheMatchButton.Click();
            return new MatchForm();
        }

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}
