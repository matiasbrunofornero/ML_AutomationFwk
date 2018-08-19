using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestFramework
{
    public class PasswordPage : Browser
    {
        [FindsBy(How = How.CssSelector, Using = "input.andes-form-control__field")]
        private IWebElement _passwordInput;

        [FindsBy(How = How.Id, Using = "action-complete")]
        private IWebElement _accept;

        public PasswordPage(IWebDriver driver) : base(driver) { }

        public void SetPassword(String pass)
        {
            _passwordInput.SendKeys(pass);
        }

        public void ClickAccept()
        {
            _accept.Click();
        }
    }
}