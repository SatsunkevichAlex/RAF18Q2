using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
	public class ElementsList
	{
		private By locator;
        private BaseElement parent;

		public List<IWebElement> Elements
		{
			get
			{
                Browser.Wait.Until(ExpectedConditions.ElementExists(locator));
                return parent == null ? Browser.Driver.FindElements(locator).ToList() : parent.Element.FindElements(locator).ToList();
            }
		}

		public ElementsList(By locator)
		{
			this.locator = locator;
		}

        public ElementsList(By locator, BaseElement parent)
        {
            this.locator = locator;
            this.parent = parent;
        }

        private string Standartdize(string text)
		{
			return text.ToLower().Trim();
		}

		public void ClickElement(string elementName)
		{
			IWebElement element = Elements.FirstOrDefault(t => Standartdize(t.Text) == Standartdize(elementName));
			(new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(5))).Until(ExpectedConditions.ElementToBeClickable(element));
			element.Click();
		}

		public void JSClickElement(string elementName)
		{
            elementName = Standartdize(elementName);
            IWebElement element = Elements.FirstOrDefault(t => Standartdize(t.Text) == elementName);
			(new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(5))).Until(ExpectedConditions.ElementToBeClickable(element));
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
			executor.ExecuteScript("arguments[0].click();", element);
		}

        public void JSClickElement(int index)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
            executor.ExecuteScript("arguments[0].click();", Elements[index]);
        }

        public IWebElement this[int index]
		{
			get
			{
				return Elements[index];
			}
		}

        public int Count => Elements.Count;
	}
}