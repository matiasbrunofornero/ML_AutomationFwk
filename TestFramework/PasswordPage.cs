using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestFramework
{
    public class PasswordPage : Browser
    {
        [FindsBy(How = How.CssSelector, Using = ".auth-textinput #password")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.Id, Using = "action-complete")]
        private IWebElement _accept;

        public PasswordPage(IWebDriver driver) : base(driver) { }

        public void SetPassword(String pass)
        {
            CleanSendKeys(_passwordInput, pass);
        }

        public HomePage ClickAccept(IWebDriver driver)
        {
            _accept.Click();
            return new HomePage(driver);

        }
    }
}