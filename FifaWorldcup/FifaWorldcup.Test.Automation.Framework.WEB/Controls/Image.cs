using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
    public class Image : BaseElement
    {
        public Image(By locator) : base(locator)
        {
        }

        public Image(By locator, BaseElement parent) : base(locator, parent)
        {
        }
    }
}
