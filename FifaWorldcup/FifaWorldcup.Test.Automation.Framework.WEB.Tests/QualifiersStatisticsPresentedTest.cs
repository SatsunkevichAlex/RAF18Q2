using NUnit.Framework;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Tests
{
    [TestFixture]
    public class QualifiersStatisticsPresentedTest : BaseWebTest
    {
        [Test]
        public void QualifiersStatisticsPresented()
        {
            HomeForm homeForm = new HomeForm();
            Assert.IsTrue(homeForm.IsHomeFormTitleDisplayed);

            homeForm.OpenDropDownMenu();
            Assert.IsTrue(homeForm.IsDropDownMenuOpen);

            QualifiersForm qualifiersForm = homeForm.GoToQualifiresForm();
            Assert.IsTrue(qualifiersForm.IsStatisticsVisible);
        }
    }
}
