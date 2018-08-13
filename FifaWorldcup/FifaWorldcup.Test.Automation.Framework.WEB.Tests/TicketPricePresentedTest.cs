using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class TicketPricePresentedTest : BaseWebTest
    {
        [Test]
        public void TicketPricePresented()
        {
            HomeForm homeForm = new HomeForm();
            Assert.IsTrue(homeForm.IsHomeFormTitleDisplayed);

            TicketingForm ticketingForm = homeForm.GoToTicketingForm();
            Assert.IsTrue(ticketingForm.IsFormTitleVisible);

            ticketingForm.ScrollToTicketPriceArea();
            Assert.IsTrue(ticketingForm.IsTicketPriceAreaVisible);

            TicketPricesForm ticketPriceForm = ticketingForm.GoToTicketPrices();
            Assert.IsTrue(ticketPriceForm.IsPriceVisible);
        }
    }
}
