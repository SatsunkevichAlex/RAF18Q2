using FifaWorldcup.Test.Automation.Framework.WEB.BaseObjects;
using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using FifaWorldcup.Test.Automation.Framework.WEB.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class SearchForm : BaseForm
    {
        private Button search => Has<Button>(By.XPath("//div[@class='fi-search__wrap']//input[@name='q']"));
        private Button searchicon => Has<Button>(By.XPath("//*[@class='fi-site-header__dropdown__search']//*[@class='fi-svg-icon icon-search']"));
        public SearchForm() : base(By.Name("q"))
        { }

        public bool Search(string text)
        {
            Log.Info($"Search for {text}");

            search.SendKeys(text);
            searchicon.Click();
            InfoFieldForm info = new InfoFieldForm();
            bool aresomenews= info.AreNews();
            return aresomenews;
        }
    }
}