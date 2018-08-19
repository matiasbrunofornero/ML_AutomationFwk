using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestFramework
{
    public class ResultsPage : Browser
    {
        [FindsBy(How = How.CssSelector, Using = ".breadcrumb__title")]
        private IWebElement _breadcrumbTitle;

        public ResultsPage(IWebDriver driver) : base(driver) { }

        public String GetBreadcrumbTitle()
        {
            return _breadcrumbTitle.Text;
        }

        public bool IsAtResultsPage(String title)
        {
            return GetBreadcrumbTitle().Equals(title);
        }
    }
}
