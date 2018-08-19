using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
#pragma warning disable CS0618 // Type or member is obsolete

namespace TestFramework
{
    public class HomePage : Browser
    {
        static String PageTitle = "Mercado Libre Argentina";

        [FindsBy(How = How.CssSelector, Using = "input.nav-search-input")]
        private IWebElement _searchBox;

        [FindsBy(How = How.CssSelector, Using = ".nav-search button.nav-search-btn")]
        private IWebElement _searchButton;

        [FindsBy(How = How.CssSelector, Using = ".option-register")]
        private IWebElement _registerButton;

        [FindsBy(How = How.CssSelector, Using = ".option-login")]
        private IWebElement _loginButton;

        public HomePage(IWebDriver driver) : base(driver){}

        public LoginPage ClickLogin(IWebDriver driver)
        {
            _loginButton.Click();
            return new LoginPage(driver);
        }

        public void SetSearch(String search)
        {
            _searchBox.SendKeys(search);
            _searchButton.Click();
        }

        public bool IsAt()
        {
            return Browser.GetTitle().Equals(PageTitle);
        }
    }
}
