using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class StoreForm : BaseForm
    {
        private Button ItemButton = new Button(By.XPath("//div[@class='title']"));
        private static LabelText form = new LabelText(By.XPath("//div[@name='ibmMainContainer']"));

        private LabelText itemDescription = new LabelText(By.XPath("//a[@class='ps-page-navigator product-title']"));
        private LabelText itemPrice = new LabelText(By.XPath("//span[@class='price is-Full-Price']"));

        public StoreForm() : base(form.Locator)
        { }

        public StoreItemForm SelectProduct()
        {
            Log.Info("Select product");
            ItemButton.Click();
            return new StoreItemForm();
        }

        public bool IsStoreTitleDisplayed => Browser.Instance.GetFormTitle != null;

        public bool IsItemDescriptionPresented => itemDescription.Displayed;

        public bool IsItemPricePresented => itemPrice.Displayed;
    }
}