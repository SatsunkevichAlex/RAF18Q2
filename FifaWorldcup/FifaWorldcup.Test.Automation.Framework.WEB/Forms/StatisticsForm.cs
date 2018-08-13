using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class StatisticsForm : BaseForm
	{
		public TeamBriefStatisticsForm topAttacking => Has<TeamBriefStatisticsForm>(By.XPath("//div[@class='fi-statistics__post-content fi-statistics__teams']//div[contains(text(), 'Attacking')]/parent::*"), "attacking");
		
		public StatisticsForm() : base(By.XPath("//h1"))
		{
		}
	}
}
