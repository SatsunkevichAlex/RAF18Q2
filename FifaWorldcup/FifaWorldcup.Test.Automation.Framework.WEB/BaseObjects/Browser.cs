using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects
{
    public class Browser
    {
        private static Browser currentInstane;
        private static IWebDriver _driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
        public static int ImplWait;
        public static double TimeoutForElement;
		private static string browserName;

        public static WebDriverWait Wait => new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(TimeoutForElement));

		private Browser()
        {
            ImplWait = Convert.ToInt32(ConfigurationManager.AppSettings["ImplicitWait"]);
            TimeoutForElement = Convert.ToDouble(ConfigurationManager.AppSettings["ElementTimeout"]);
            browserName = ConfigurationManager.AppSettings["Browser"];
            Enum.TryParse(browserName, out CurrentBrowser);
            _driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);
        }

        public static Browser Instance => currentInstane ?? (currentInstane = new Browser());

        public static IWebDriver Driver => _driver;

        public static string Url
        {
            get  { return _driver.Url; }
            set { _driver.Url = value; }
        }

        public string GetFormTitle => _driver.Title;

        public static void Maximise() => _driver.Manage().Window.Maximize();

        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            _driver.Quit();
            _driver = null;
            currentInstane = null;
        }

        public string GetRandomEmail()
        {
            string currentPage = Browser.Driver.CurrentWindowHandle;
            OpenNewTab(ConfigurationManager.AppSettings["10 min random email"]);
            var randomEmailForm = new RandomEmailForm();
            string randomEmail = randomEmailForm.EmailAddress;
            Driver.SwitchTo().Window(currentPage);
            return randomEmail;
        }

        public IWebElement FindElement(By locator)
        {
            try
            {
                return (new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeoutForElement)))
                    .Until(driver =>
                    {
                        return driver.FindElement(locator);
                    });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            try
            {
                return (new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeoutForElement)))
                    .Until(driver =>
                    {
                        return driver.FindElements(locator);
                    });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string OpenNewTab(string newTabUrl)
        {
            var handle = _driver.CurrentWindowHandle;
            var handles = _driver.WindowHandles;
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript(string.Format("var d=document, a=d.createElement('a');a.target='_blank';a.href='{0}';" +
                                           "a.innerHtml='.';d.body.appendChild(a),a.click();", newTabUrl));
            try
            {
                (new WebDriverWait(_driver, TimeSpan.FromSeconds(Convert.ToDouble(TimeoutForElement))))
                    .Until(driver =>
                    (_driver.WindowHandles.Count > handles.Count)
                    );
            }
            catch (Exception)
            {
                Console.Out.WriteLine("New Tab wasn't beed opened");
            }
            var handlesAfterOpen = _driver.WindowHandles;
            string newTabHandle = string.Empty;
            foreach (var newHandle in handlesAfterOpen)
            {
                if (!(handles.Contains(newHandle)))
                {
                    newTabHandle = newHandle;
                    break;
                }
            }
            _driver.SwitchTo().Window(newTabHandle);
            return newTabHandle;
        }

        public static void SwitchToOpenedTab()
        {
            var handle = _driver.CurrentWindowHandle;
            var handles = _driver.WindowHandles;
            string newHandle = handles.First(t => t != handle);
            _driver.SwitchTo().Window(newHandle);
        }
    }
}