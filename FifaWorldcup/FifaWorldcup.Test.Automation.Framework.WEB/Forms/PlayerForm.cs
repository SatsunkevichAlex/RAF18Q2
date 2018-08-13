using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class PlayerForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        private LabelText dateOfBirth => Has<LabelText>(By.XPath("//*[contains(text(), 'Date of Birth')]"));
        private ElementsList matches => Has<ElementsList>(By.XPath("//div[@class = 'fi-mu result']"));

        public PlayerForm() : base(form.Locator)
        { }

        public bool IsDisplay => dateOfBirth.Displayed;

        public MatchSummaryForm SelectMatch(int numberOfMatch)
        {
            Log.Info("Select match");
            matches.JSClickElement(numberOfMatch);
            return new MatchSummaryForm();
        }

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}