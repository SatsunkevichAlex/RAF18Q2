using System.Collections.Generic;
using System.Linq;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
	class GroupTable : BaseElement
	{
		public string GroupName { get; private set; }
		public List<string> TeamsNames { get; private set; }
		private Button _groupAnalisysButton;

		public GroupTable(By locator) : base(locator)
		{
			InitElements();
		}

		public void InitElements()
		{
			GroupName = Has<LabelText>(By.XPath(".//p[@class='fi-table__caption__title fi-ltr--force']"), this).Text;
			TeamsNames = Has<ElementsList>(By.XPath(".//tbody//tr[@data-team-id]//span[@class='fi-t__nText ']"), this).Elements.Select((t) => t.Text).ToList<string>();
			_groupAnalisysButton = Has<Button>(By.XPath(".//a[@class='fi-o-media-object__link']"), this);
		}

		public GroupAnalysisForm GoToGroupAnalisys()
		{
			_groupAnalisysButton.JsClick();
			return new GroupAnalysisForm();
		}
	}
}
