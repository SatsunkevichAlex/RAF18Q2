using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class StoreItemForm : BaseForm
    {
        static LabelText formTitle = new LabelText(By.XPath("(//h2[@class='title'])[1]"));
        private LabelText itemDescription = new LabelText(By.XPath("//div[@class='columns small-12 title-container']//h2[@class='title']"));
        private LabelText itemPrice = new LabelText(By.XPath("(//span[@class='price is-Full-Price'])[1]"));
        private Button addToCartButton = new Button(By.XPath("//p[text()='ADD TO CART']"));

        public StoreItemForm() : base(formTitle.Locator)
        { }

        public bool IsPossibleAddToCart => addToCartButton.IsClickable();

        public bool IsItemDescriptionDisplayed => itemDescription.Displayed;

        public bool IsItemPriceDisplayed => itemPrice.Displayed;
    }
}