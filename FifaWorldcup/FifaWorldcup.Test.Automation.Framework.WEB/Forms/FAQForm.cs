using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
	public class FAQForm : BaseForm
	{
        private LabelText _title = new LabelText(By.XPath("//h1[@class='title']/span"));

        public ElementsList FAQTopics
		{
			get
			{
				return new ElementsList(By.XPath("//span[@class='faq-question-text']"));
			}
		}

        public FAQForm() : base(By.XPath("//h1/span"))
        {
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