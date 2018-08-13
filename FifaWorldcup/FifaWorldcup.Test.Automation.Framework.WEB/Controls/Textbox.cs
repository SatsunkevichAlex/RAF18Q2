using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
    public class Textbox : BaseElement
    {
        public Textbox(By locator) : base(locator)
        {
        }

        public Textbox(By locator, BaseElement parent) : base(locator, parent)
        {
        }
    }
}
