using FifaWorldcup.Test.Automation.Framework.CORE;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public abstract class BaseForm
    {
        public By Locator { get; private set; }
        public Logger Log => new Logger(this.GetType());

        protected BaseForm(By Locator)
        {
            this.Locator = Locator;
            this.WaitForLoadingPage();
            this.Log.Info($"Page <{this.GetType().Name}> is opened");
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

        public string Title => Browser.Driver.Title;

        public WebDriverWait Wait => Browser.Wait;

        public void WaitForLoadingPage()
        {
            Log.Info("Wait page loading...");
            Wait.Until(
            driver =>
            {
                var result = Browser.Driver.ExecuteJavaScript<string>("return document.readyState").Equals("complete");
                return result;
            });
            Wait.Until(ExpectedConditions.ElementExists(this.Locator));
        }
    }
}