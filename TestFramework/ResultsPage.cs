using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestFramework
{
    public class ResultsPage : Browser
    {
        [FindsBy(How = How.CssSelector, Using = ".breadcrumb__title")]
        private IWebElement _breadcrumbTitle;

        [FindsBy(How = How.CssSelector, Using = "#results-section .results-item")]
        private IList<IWebElement> _results;

        public ResultsPage(IWebDriver driver) : base(driver){}

        public String GetBreadcrumbTitle()
        {
            return _breadcrumbTitle.Text;
        }

        private IList<IWebElement> GetResults()
        {
            return _results;
        }

        public ResultSummary ClickResult(int item, IWebDriver webDriver)
        {
            IList<IWebElement> results = GetResults();
            ClickElement(results[item].FindElement(By.TagName("a")));
            return new ResultSummary(webDriver);
        }
    }
}
