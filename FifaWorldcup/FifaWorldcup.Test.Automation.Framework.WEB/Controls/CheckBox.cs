using OpenQA.Selenium;
using System.Collections.Generic;

namespace FifaWorldcup.Test.Automation.Framework.WEB.Controls
{
    public class CheckBox : BaseElement
    {
        IWebElement element;
        bool IsChecked;

        public CheckBox(By locator) : base(locator)
        {
            this.element = Element;
            this.IsChecked = Element.Selected;
        }

        public CheckBox(By locator, BaseElement parent) : base(locator, parent)
        {
        }

        public void ClickCheckBox()
        {
            if (!IsChecked)
            {
                WaitForIsVisible();
                element.Click();
            }
        }

        public bool IsClicked() => element.Selected;

        /// <summary>
        /// this method activate all checkboxes if they are not activated
        /// </summary>
        /// <param name="elements">list of elements that we should be clicked if they are not pressed</param>
        public void ActivateAllCheckboxes(List<IWebElement> elements)
        {
            foreach (IWebElement element in elements)
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
        }
    }
}
