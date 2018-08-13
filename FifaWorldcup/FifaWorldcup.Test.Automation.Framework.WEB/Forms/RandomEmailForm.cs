using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class RandomEmailForm : BaseForm 
    {
        static LabelText formTitle = new LabelText(By.XPath("//div[@id='wrapper']"));
        static Textbox emailField = new Textbox(By.XPath("//input[@class = 'mailtext']"));

        public string EmailAddress => this._emailField.Text;

        Textbox _emailField = new Textbox(emailField.Locator);

        public RandomEmailForm() : base(formTitle.Locator)
        { }
    }
}