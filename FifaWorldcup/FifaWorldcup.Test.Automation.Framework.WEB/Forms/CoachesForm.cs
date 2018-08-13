using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.CORE;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class CoachesForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        public ElementsList CoachesList => Has<ElementsList>(By.XPath("//div[@class = 'col-xs-12 col-sm-3 col-md-3 col-lg-3 col-flex']"));

        public CoachesForm() : base(form.Locator)
        { }

        public CoachForm GoToCoachForm(int numberOfCoach)
        {
            Log.Info("Opening random coach profile");
            CoachesList.Elements[numberOfCoach].Click();
            return new CoachForm();
        }

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}