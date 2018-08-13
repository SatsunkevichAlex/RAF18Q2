using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class LoginForm : BaseForm
    {
        private Textbox loginEntryItem => Has<Textbox>(By.XPath("//input[@type='email']"));
        private Textbox passwordEntryItem => Has<Textbox>(By.XPath("//input[@type='password']"));
        private Button signIn => Has<Button>(By.XPath("//button[@id='next']"));
        private Button connectFacebook => Has<Button>(By.XPath("//button[@id='FacebookExchange']"));
        private Button connectGoogle => Has<Button>(By.XPath("//button[@id='GoogleExchange']"));
        private Button registerByEmail => Has<Button>(By.XPath("//button[@id='create_button_link']"));
        public LabelText WrongDataAlert => Has<LabelText>(By.XPath("//p[@role ='alert']"));


        public LoginForm() : base(By.XPath("//div[@class='panel']"))
        {
        }

        public void SubmitLoginForm(string email, string password)
        {
            Log.Info("Submit login");
            loginEntryItem.SendKeys(email);
            passwordEntryItem.SendKeys(password);
        }

        public void SignIn()
        {
            Log.Info("Sign in");
            if (signIn.IsClickable) signIn.Click();
        }

        public void SignInByEmail()
        {
            Log.Info("Sign in by email");
            if (registerByEmail.IsClickable) registerByEmail.Click();
        }

        public void ConnectFacebook()
        {
            Log.Info("Sign in by Facebook");
            if (connectFacebook.IsClickable) connectFacebook.Click();
        }

        public void ConnectGoogle()
        {
            Log.Info("Connect Google");
            if (connectGoogle.IsClickable) connectGoogle.Click();
        }

        public string GetAllert => WrongDataAlert.Text;
    }
}
