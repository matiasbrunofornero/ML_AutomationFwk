using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestFramework
{
    public class LoginPage : Browser
    {
        [FindsBy(How = How.CssSelector, Using = "input.auth-form_input")]
        private IWebElement _usernameInput;

        [FindsBy(How = How.CssSelector, Using = ".auth-button--user")]
        private IWebElement _continue;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public PasswordPage SetUsername(String user, IWebDriver driver)
        {
            CleanSendKeys(_usernameInput, user);
            ClickElement(_continue);
            return new PasswordPage(driver);
        }
    }
}
