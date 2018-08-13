using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class TeamBriefStatisticsForm : BaseForm
	{
        public string TeamName => Has<LabelText>(By.XPath(@".//a[@class='fi-t__nText ']"), this).Text;
        public int Score => int.Parse(Has<LabelText>(By.XPath(".//div[@class='fi-statistics-list-4-cols__data']/b"), this).Text);

        public TeamBriefStatisticsForm(string columnTitle) : base(By.XPath($"//ul[@class='fi-statistics-list-4-cols']//div[contains(text(), '{columnTitle}')]/parent::*"))
		{ }
	}
}