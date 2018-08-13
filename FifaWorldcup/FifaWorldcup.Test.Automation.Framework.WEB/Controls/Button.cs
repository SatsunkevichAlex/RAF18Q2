using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator)
        {
        }

        public Button(By locator, BaseElement parent) : base(locator, parent)
        {
        }

        public new bool IsClickable
		{
			get
			{
				if (Wait.Until(ExpectedConditions.ElementToBeClickable(Element)) != null)
				{
					return true;
				}
				return false;
			}
		}
    }
}