using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class ItemInShopPossibleAddToCartTest : BaseWebTest
    {
        [Test]
        public void ItemInShopPossibleAddToCart()
        {
            HomeForm homeForm = new HomeForm();
            Assert.IsTrue(homeForm.IsHomeFormTitleDisplayed);

            StoreForm storeForm = homeForm.GoToStoreForm();
            Assert.IsTrue(storeForm.IsStoreTitleDisplayed);

            StoreItemForm storeItemForm = storeForm.SelectProduct();
            Assert.IsTrue(storeItemForm.IsItemDescriptionDisplayed);
            Assert.IsTrue(storeItemForm.IsItemPriceDisplayed);
            Assert.IsTrue(storeItemForm.IsPossibleAddToCart);
        }
    }
}
