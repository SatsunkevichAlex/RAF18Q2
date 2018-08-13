using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class TeamForm : BaseForm
    {
        private LabelText _title = new LabelText(By.XPath("//span[@class='fi-t__nText ']"));
		private Button Overview => Has<Button>(By.XPath("//a[text() = 'Overview']"));
		private Button News => Has<Button>(By.XPath("//a[text() = 'News']"));
		private Button Photos => Has<Button>( By.XPath("//a[text() = 'Photos']"));
		private List<string> LineUp;
		private Button ProfileButton => Has<Button>(By.XPath("//a[contains(text(), 'Profile')]"));
        public ElementsList Matches => Has<ElementsList>(By.XPath("//div[@class='fi-mu__item']/a"));
        public By isteamlineuppresanted = By.XPath("//h1[@class='section__title '][contains(text(), 'Players')]");

        public TeamForm() : base(By.XPath("//h1"))
        {
            LineUp = new List<string>();
        }

        public List<string> GetTeamLineup()
        {
            Log.Info("Get team linup");
            Overview.Click();
            IList<IWebElement> elements = new List<IWebElement>();
            elements = Has<List<IWebElement>>(By.ClassName("fi-p__nShorter "));
            elements.ToList<IWebElement>();
            foreach (IWebElement el in elements)
            {
                LineUp.Add(el.Text);
            }
            return LineUp; ;
        }

        public bool IsTeamLineupPresented()
        {
            Log.Info("Check is team line up presented");
            bool Isteamlineuppresented = true;
            try
            {
                Button button = new Button(isteamlineuppresanted);
            }
            catch
            {
                Isteamlineuppresented = false;
            }
            return Isteamlineuppresented;
        }

        public TeamProfileForm GoToTeamProfile()
        {
            Log.Info("Open team profie");
            ProfileButton.Click();
            return new TeamProfileForm();
        }

        public new string Title
        {
            get
            {
                return _title.Text;
            }
        }

        public MatchForm GoToMatch(int n)
        {
            Log.Info("Open match");
            Matches.JSClickElement(n);
            return new MatchForm();
        }
    }
}