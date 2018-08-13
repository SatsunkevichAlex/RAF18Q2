using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class LoginPopup : BaseForm
    {
        private Button login => Has<Button>(By.XPath("//div[@class='fi-login__submit-wrap']//input[@value='Login']"));
        private Button signUpNow => Has<Button>(By.XPath("//div[@class='fi-login__submit-wrap']//input[@value='Sign Up now']"));
        private Button logOut => Has<Button>(By.XPath("//span[@class='btn btn-primary fi-btn--submit']"));
        private Button profile => Has<Button>(By.XPath("//div[@class='fi-login__userinfo']//a"));
        private LabelText username => Has<LabelText>(By.XPath("//h4//a[@target='_self']"));
        private LabelText loginDescription => Has<LabelText>(By.XPath("//p[@class='fi-login__desc']"));
        private Button close => Has<Button>(By.XPath("//span[@class='fi - site - header__dropdown__close']/child::*/child::*'"));

        public LoginPopup() : base(By.XPath("//div[@class='fi-login fi-login--logged']"))
        { }

        public void LogOut()
        {
            Log.Info("Log out");
            if (logOut.IsClickable) logOut.Click();
        }

        public void GoToUserProfile()
        {
            Log.Info("Open user profile");
            if (profile.IsClickable) profile.Click();
        }

        public void Login()
        {
            Log.Info("Log in");
            if (login.IsClickable) login.Click();
        }

        public void SignUp()
        {
            Log.Info("Sigh up");
            if (signUpNow.IsClickable) signUpNow.Click();
        }

        public string GetUsername => username.Text;

        public string GetLoginDescription => loginDescription.Text;
    }
}