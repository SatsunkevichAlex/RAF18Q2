using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TicketPricesForm : BaseForm
    {
        static LabelText formLabel = new LabelText(By.XPath("//div[@id='content-wrap']")); 
        private Image priceTicket = new Image(By.XPath("//div/img[@title='Ticket Prices in RUB']"));

        public TicketPricesForm() : base(formLabel.Locator)
        { }

        public bool IsPriceVisible => priceTicket.IsVisible();
    }
}