using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class HomeForm : BaseForm
    {
        public HomeForm() : base(By.XPath("//body"))
        { }

        private Header header = new Header();
        private DropDown dropDownMenu = new DropDown(By.XPath("//a[@data-dropdown='fi-section-header__dropdown__hamburger']"));
        private Button qualifiers = new Button(By.XPath("//a[text()='Qualifiers']"));

        public bool IsDropDownMenuOpen => dropDownMenu.IsOpened;

        public void OpenDropDownMenu() => dropDownMenu.OpenMenu();

        public MatchesForm GoToMatchesForm()
        {
            Log.Info("Open matches form");
            header.GoToSection("Matches");
            return new MatchesForm();
        }

        public PlayersForm GoToPlayersForm()
        {
            Log.Info("Open players form");
            header.GoToSection("Players");
            return new PlayersForm();
        }

        public TicketingForm GoToTicketingForm()
        {
            Log.Info("Open ticketing form");
            header.GoToSection("Ticketing");
            return new TicketingForm();
        }

        public StoreForm GoToStoreForm()
        {
            Log.Info("Open store form");
            header.GoToShop();
            return new StoreForm();
        }

        public QualifiersForm GoToQualifiresForm()
        {
            Log.Info("Open qualifiers form");
            qualifiers.JsClick();
            return new QualifiersForm();
        }

        public bool IsHomeFormTitleDisplayed => Browser.Instance.GetFormTitle != null;

        public Header Header => header;
    }
}