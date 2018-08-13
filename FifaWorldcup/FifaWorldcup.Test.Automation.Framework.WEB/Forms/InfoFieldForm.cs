using FifaWorldcup.Test.Automation.Framework.WEB.Controls;
using OpenQA.Selenium;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Forms
{
    public class InfoFieldForm : BaseForm
    {
        static Button search = new Button(By.XPath("//div[@class='fi-search__wrap']//input[@name='q']"));
        static Button searchicon = new Button(By.XPath("//*[@class='col-xs-12 col-sm-10 col-md-8  col-sm-offset-1 col-md-offset-2 ']//*[@class='fi-svg-icon icon-search']"));
        static By NewsLocator = By.ClassName("//*[@class='d3-o-media-object d3-o-media-object--horizontal fi-o-media-object--horizontal']");
        static By nonewslocator = By.XPath("//div[@class='fi-generic-wordtag']");

        public InfoFieldForm() : base(By.ClassName("fi-search__text"))
        { }

        public bool AreNews()
        {
            Log.Info("Check are news presented");
            bool arenews = false;
            try
            {
                Button button = new Button(nonewslocator);
            }
            catch
            {
                arenews = true;
            }
            return arenews;
        }
    }
}
