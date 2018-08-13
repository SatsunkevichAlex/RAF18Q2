using OpenQA.Selenium;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using System.Text.RegularExpressions;
using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using System.Linq;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class PlayerBrowserSearchByPositionForm : BaseForm
    {
        static LabelText form = new LabelText(By.XPath("//h1"));
        private ElementsList numberOfPlayersInAllPosition => Has<ElementsList>(By.XPath("//a[@class = 'fi-p__filter-content__position']"));
        private Button teamButton => Has<Button>(By.XPath("//span[text() = 'Team']"));
        private ElementsList playersList => Has<ElementsList>(By.XPath("//div[@id='team-players-by-browser']//a[@class='fi-p--link ']"));

        public PlayerBrowserSearchByPositionForm() : base(form.Locator)
        { }

        public PlayerForm GetInfo(int numberOfPlayer)
        {
            Log.Info($"get info about player number {numberOfPlayer}");
            playersList.Elements[numberOfPlayer].Click();
            return new PlayerForm();
        }

        public PlayerBrowserSearchByTeamForm SelectTeam()
        {
            Log.Info("Select team");
            teamButton.JsClick();
            return new PlayerBrowserSearchByTeamForm();
        }

        public int Sum()
        {
            Log.Info("Count summary of all players");

            string numbersInBracketsRegex = @"-?\d+([0-9,\.,\,,\s])*";
            int sumAllPositions = 0;
            foreach (var position in numberOfPlayersInAllPosition.Elements.Select(t => t.Text.Trim()))
            {
                Match match = Regex.Match((position), numbersInBracketsRegex);
                if (match.Success)
                {
                    sumAllPositions += int.Parse(match.Value);
                }
            }
            return sumAllPositions;
        }

        public bool IsCorrect => Sum() == playersList.Count;

        public bool IsFormTitleDisplay => Browser.Instance.GetFormTitle != null;
    }
}