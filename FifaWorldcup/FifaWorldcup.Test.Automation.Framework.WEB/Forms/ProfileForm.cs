using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class ProfileForm : BaseForm
    {
        private Textbox firstName => Has<Textbox>(By.XPath("//input[@id='i_FirstName']"));
        private Textbox lastName => Has<Textbox>(By.XPath("//input[@id='i_LastName']"));
        private Button save => Has<Button>(By.XPath("//input[@id='i_btnChangeProfile']"));
        private LabelText userEmail => Has<LabelText>(By.XPath("//span[@id='i_Email']"));

        public ProfileForm() : base(By.XPath("//div[@class='container']"))
        { }

        public void UpdateFirstName(string text)
        {
            Log.Info("Update first name");
            firstName.SendKeys(text);
            if (save.IsClickable) save.Click();
        }

        public void UpdateLastName(string text)
        {
            Log.Info("Update last name");
            lastName.SendKeys(text);
            if (save.IsClickable) save.Click();
        }

        public string UserEmail => userEmail.Text;
    }
}
