using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class LanguagePopupForm : BaseForm
    {
        private ElementsList languages => Has<ElementsList>(By.XPath("//li[@data-value]//a"));
        private Button close => Has<Button>(By.XPath("//span[@class='fi - site - header__dropdown__close']/child::*/child::*"));

        public LanguagePopupForm() : base(By.XPath("//div[@class='fi-site-header__dropdown__lang fi-site-header__dropdown--vertical']"))
        { }

        public void ChangeLanguage(string language)
        {
            Log.Info("Change language");
            languages.JSClickElement(language);
        }

        public void Close()
        {
            Log.Info("Close language pop up");
            if (close.IsClickable) close.Click();
        }

        public bool CloseIsClickable => close.IsClickable;
    }
}
