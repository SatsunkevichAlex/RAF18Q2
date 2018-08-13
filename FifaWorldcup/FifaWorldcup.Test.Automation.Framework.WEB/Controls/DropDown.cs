using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
	public class DropDown : BaseElement
	{
		public bool IsOpened { get; private set; }
		public bool ItemsDisplayed => VariantsList.Elements.All(element =>
                                        {
											Browser.Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", this.Element);
											return element.Displayed;
                                        });

		public BaseElement OpenButton { get; set; }
	
		public ElementsList VariantsList => Has<ElementsList>(By.XPath("//ul[@class='dropdown-menu']/li/child::*"));

		public DropDown(By locator) : base(locator)
		{
		}

        public DropDown(By locator, BaseElement parent) : base(locator, parent)
        {
        }

        public void OpenMenu()
		{
			if (IsOpened) return;
			var openButton = this.OpenButton ?? this;
			Wait.Until(ExpectedConditions.ElementToBeClickable(openButton.Element));
			openButton.Click();
			IsOpened = true;
		}

		private string Standardize(string text)
		{
			return text.ToLower().Trim();
		}

		public void ClickVariant(string option)
		{
			if (IsOpened == true)
			{
				VariantsList.Elements.First(t => t.Text == option).Click();
			}
		}
	}
}