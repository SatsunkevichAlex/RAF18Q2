using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
	public abstract class BaseElement
	{
		public static WebDriverWait Wait
		{
			get
			{
                return Browser.Wait;
			}
		}
		public By Locator { get; private set; }

        public BaseElement _parentElement
        {
            get;
            private set;
        }

        public BaseForm _parentForm
        {
            get;
            private set;
        }

		public IWebElement Element
		{
			get
			{
                IWebElement element;
				if (_parentElement == null && _parentForm != null)
                {
                    // find by parent form
                    // Please, only one level of depth required
                    element = Browser.Driver.FindElement(_parentForm.Locator).FindElement(Locator); 
                }
                else if (_parentElement != null && _parentForm == null)
                {
                    // find by parent element
                    // recuirsevly find element until parentform ruins EVERYTHING
                    element = _parentElement.Element.FindElement(Locator);
                }
                else
                {
                    element = Browser.Driver.FindElement(Locator);
                }
                return element;
            }
			private set
			{
				Element = value;
			}
		}

		public BaseElement(By locator)
		{
			this.Locator = locator;
			this.WaitForIsVisible();
		}

        public BaseElement(By locator, BaseElement parent)
        {
            this.Locator = locator;
            this._parentElement = parent;
            this.WaitForIsVisible();
        }

        public BaseElement(By locator, BaseForm parent)
        {
            this.Locator = locator;
            this._parentForm = parent;
            this.WaitForIsVisible();
        }

		public string Text => Element.Text;

		public bool Enabled => Element.Enabled;

		public bool Selected => Element.Selected;

		public Point Location => Element.Location;

		public Size Size => Element.Size;

		public bool Displayed => Element.Displayed;

		public void WaitForIsVisible()
		{
			new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(ExpectedConditions.ElementExists(Locator));
		}

		public bool IsVisible()
		{
			try
			{
				new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(ExpectedConditions.ElementIsVisible(Locator));
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool IsClickable()
		{
			try
			{
				new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(ExpectedConditions.ElementToBeClickable(Locator));
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void Click()
		{
			this.WaitForIsVisible();
			Element.Click();
		}

		public void JsClick()
		{
			this.WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.Driver;
			executor.ExecuteScript("arguments[0].click();", this.Element);
		}

		public void Clear()
		{
			Element.Clear();
		}

		public void SendKeys(string text)
		{
			Element.SendKeys(text);
		}

		public void Submit()
		{
			Element.Submit();
		}

		public string GetAttribute(string attributeName)
		{
			return Element.GetAttribute(attributeName);
		}

		public string GetProperty(string propertyName)
		{
			return Element.GetProperty(propertyName);
		}

		public string GetCssValue(string propertyName)
		{
			return Element.GetCssValue(propertyName);
		}

		public IWebElement FindElement(By locator)
		{
			return Element.FindElement(locator);
		}

		public ReadOnlyCollection<IWebElement> FindElements(By locator)
		{
			return Element.FindElements(locator);
		}

		public T Has<T>(By locator)
		{
			return (T)Activator.CreateInstance(typeof(T), locator);
		}

        public T Has<T>(By locator, string name)
        {
            return (T)Activator.CreateInstance(typeof(T), locator, name);
        }

        public T Has<T>(By locator, BaseForm parent)
        {
            return (T)Activator.CreateInstance(typeof(T), locator, parent);
        }

        public T Has<T>(By locator, BaseElement parent)
        {
            return (T)Activator.CreateInstance(typeof(T), locator, parent);
        }

        public void ScrollToElement()
		{
			Browser.Driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", this.Element);
		}
	}
}