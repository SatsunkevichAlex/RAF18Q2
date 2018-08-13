using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms

{
    public class MatchStatisticsForm : BaseForm
    {
        private static LabelText statistics = new LabelText(By.XPath("//td[text()='Goals']"));

        public MatchStatisticsForm() : base(statistics.Locator)
        { }

        public bool IsStatisticsPresented => statistics.IsVisible();
    }
}
