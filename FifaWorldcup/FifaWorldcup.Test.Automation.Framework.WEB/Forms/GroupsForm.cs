using System.Collections.Generic;
using System.Linq;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class GroupsForm : BaseForm
    {
        private LabelText _title => Has<LabelText>(By.XPath("//h1[@class='fi-pageheader__title']"));
        private ElementsList _groupsList => Has<ElementsList>(By.XPath("//ul[@class='fi-page-nav__menu']//a/span"));
        private List<GroupTable> _groupTablesList;

        public GroupsForm() : base(By.XPath("//section[@class='section']//div[@class='row']"))
        {
            InitElements();
        }

        private void InitElements()
        {
            Log.Info("Create group table list");
            _groupTablesList = new List<GroupTable>();
            for (int i = 1; i <= Has<ElementsList>(By.XPath("//table[@class]")).Count; i++)
            {
                _groupTablesList.Add(new GroupTable(By.XPath($"//table[@class][{i}]")));
            }
            _groupsList.ClickElement("Group A");
        }

        public void ScrollToGroup(string groupName)
        {
            Log.Info("Scroll to group");
            _groupsList.ClickElement(groupName);
        }

        public GroupAnalysisForm GoToGroup(string groupName)
        {
            Log.Info("Open group analysis form");
            _groupTablesList.First(t => t.GroupName.ToLower() == groupName.ToLower()).GoToGroupAnalisys();
            return new GroupAnalysisForm();
        }

        public bool GroupIsDisplayed(string groupName)
        {
            return _groupTablesList.First(t => t.GroupName.ToLower() == groupName.ToLower()).Displayed;
        }

        public new string Title
        {
            get
            {
                return _title.Text;
            }
        }

        public List<string> TeamNames(string groupName) => _groupTablesList.First(t => t.GroupName.ToLower() == groupName.ToLower()).TeamsNames;
    }
}