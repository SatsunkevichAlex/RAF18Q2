using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class QualifiersForm : BaseForm
    {
        static LabelText formLabel = new LabelText(By.XPath("//div[@id='content-wrap']"));
        private LabelText qualifiresStatistics = new LabelText(By.XPath("//div[@class='preliminaries-header']"));

        public QualifiersForm() : base(formLabel.Locator)
        { }

        public bool IsStatisticsVisible => qualifiresStatistics.IsVisible();
    }
}