using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class GroupAnalysisForm : BaseForm
	{
		public List<string> TeamsNames
		{
			get
			{
				return Has<ElementsList>(By.XPath("//strong/a[@href]")).Elements.Select(t => t.Text).ToList();
			}
			private set
			{
				TeamsNames = value;
			}
		}

        public GroupAnalysisForm() : base(By.XPath("//h1[@class='d3-o-article__title fi-article__title col-xs-12']"))
        {
        }
    }
}