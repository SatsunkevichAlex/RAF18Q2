using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TeamProfileForm : BaseForm
    {
        private LabelText _teamName => Has<LabelText>(By.XPath("//div[@class='st-OpenSans-bold st-xxx-large']/i"));

        public TeamProfileForm() : base(By.XPath("//div[@class='st-copy st-col__1-1']"))
        {
        }

        public string TeamName
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(_teamName.Locator));
                return _teamName.Text;
            }
        }

        public bool? TeamNameIsDisplayed => _teamName.Displayed;
    }
}
