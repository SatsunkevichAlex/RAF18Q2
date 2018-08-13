using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class FanZoneForm : BaseForm
	{
        private LabelText _title = new LabelText(By.XPath("//h1[@class='fi-page-title']"));

		private Button FAQButton = new Button(By.XPath("//span[@class='d3-o-media-object__title fi-o-media-object__title'][contains(text(), 'FAQ')]"));

		public FanZoneForm() : base(By.XPath("//h1"))
		{
		}

		public FAQForm GoToFAQ()
		{
            Log.Info("Opening FAQ");
			if (FAQButton.IsClickable) FAQButton.JsClick();
            Browser.SwitchToOpenedTab();
            return new FAQForm();
		}

        public new string Title
        {
            get
            {
                return _title.Text;
            }
        }
	}
}
