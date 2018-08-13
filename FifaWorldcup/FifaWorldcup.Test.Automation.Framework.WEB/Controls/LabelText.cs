using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
    public class LabelText : BaseElement
    {
		public LabelText(By locator) : base(locator)
        {
        }

        public LabelText(By locator, BaseElement parent) : base(locator, parent)
        {
        }

        public LabelText(By locator, BaseForm parent) : base(locator, parent)
        {
        }
    }
}