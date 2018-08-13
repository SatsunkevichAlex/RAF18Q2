using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class CoachForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        public LabelText Country => Has<LabelText>(By.XPath("//div[contains(text(), 'Country')]"));

        public CoachForm() : base(form.Locator)
        { }

        public bool IsDisplay => Country.Displayed;

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}