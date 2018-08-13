using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TicketingForm : BaseForm
    {
        private static LabelText form = new LabelText(By.XPath("//div[@id='content-wrap']"));
        private LabelText ticketingArea = new LabelText(By.XPath("//span[text()='SeoTitle selected: ticket-prices']/.."));
        private Button ticketPrices = new Button(By.XPath("//a//span[text() = 'Ticket Prices']"));

        public TicketingForm() : base(form.Locator)
        { }

        public bool IsFormTitleVisible => Browser.Instance.GetFormTitle != null;

        public bool IsTicketPriceAreaVisible => ticketingArea.IsVisible();

        public TicketPricesForm GoToTicketPrices()
        {
            Log.Info("Open ticket price form");
            ticketPrices.JsClick();
            return new TicketPricesForm();
        }

        public void ScrollToTicketPriceArea() => ticketingArea.ScrollToElement();
    }
}