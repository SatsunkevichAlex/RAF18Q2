using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class Header : BaseForm
    {
        ElementsList sectionHeaderMenu = new ElementsList(By.XPath("//ul[@class='fi-section-header__nav']//a"));
        private Button liveScores => Has<Button>(By.XPath("//a[@title='Live Scores']"));
        private Button store => Has<Button>(By.XPath("//a[@title='Store']"));
        private Button login => Has<Button>(By.XPath("//a[@title='Login']"));
        private Button language => Has<Button>(By.XPath("//a[@data-dropdown='fi-site-header__dropdown__lang'] "));
        private Button search => Has<Button>(By.XPath("//a[@title='Search']"));
        private Button facebook => Has<Button>(By.XPath("//a[@class='fi-social-channels__fb--f']"));
        private Button twitter => Has<Button>(By.XPath("//a[@class='fi-social-channels__tw--circle']"));
        private Button instagram => Has<Button>(By.XPath("//a[@class='fi-social-channels__instagram']"));
        private Button youtube => Has<Button>(By.XPath("//a[@class='fi-social-channels__youtube']"));
        private Button weibo => Has<Button>(By.XPath("//a[@class='fi-social-channels__we--f']"));
        private LabelText title => Has<LabelText>(By.XPath("//h1[@class='fi-section-header__competition__title']"));

        public Header() : base(By.XPath("//div[@class='fi-section-header__wrap']"))
        { }

        public void GoToLiveScores()
        {
            Log.Info("Open live scores");
            if (liveScores.IsClickable) liveScores.Click();
        }

        public void GoToShop()
        {
            Log.Info("Open store");
            if (store.IsClickable) store.Click();
        }

        public void OpenLoginForm()
        {
            Log.Info("Open Log in form");
            if (login.IsClickable) login.Click();
        }

        public void OpenLanguageList()
        {
            Log.Info("Open language list");
            if (language.IsClickable) language.Click();
        }

        public void OpenSearchLine()
        {
            Log.Info("Click on search line"); 
            if (search.IsClickable) search.Click();
        }

        public void GoToFacebook()
        {
            Log.Info("Redirect to Facebook");
            if (facebook.IsClickable) facebook.Click();
        }

        public void GoToTwitter()
        {
            Log.Info("Redirect to Twitter");
            if (twitter.IsClickable) twitter.Click();
        }

        public void GoToInstagram()
        {
            Log.Info("Redirect to instagramm");
            if (instagram.IsClickable) instagram.Click();
        }

        public void GoToYoutube()
        {
            Log.Info("Redirect to YouTube");
            if (youtube.IsClickable) youtube.Click();
        }

        public void GoToWeibo()
        {
            Log.Info("Open Weibo");
            if (weibo.IsClickable) weibo.Click();
        }

        public void GoToSection(string section)
        {
            Log.Info($"Open element <{section}> in section");
            sectionHeaderMenu.ClickElement(section);
        }

        public string GetTitleText => title.Text;
    }
}