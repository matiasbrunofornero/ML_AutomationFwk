using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace TestFramework
{
    public class RegisterPage : Browser
    {
        [FindsBy(How = How.Id, Using = "signupFirstName")]
        private IWebElement _inputName;

        [FindsBy(How = How.Id, Using = "signupLastNamePosition")]
        private IWebElement _inputLastname;

        [FindsBy(How = How.Id, Using = "signupEmailPosition")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.Id, Using = "signupPasswordPosition")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.CssSelector, Using = ".form-footer > button")]
        private IWebElement _buttonCreate;

        [FindsBy(How = How.CssSelector, Using = ".ch-validation-message:nth-of-type(1)")]
        private IList<IWebElement> _errorMessage;

        [FindsBy(How = How.Id, Using = "skip-password-modal")]
        private IWebElement _noPasswordPopup;

        public RegisterPage(IWebDriver driver) : base(driver) { }

        public RegisterPage SetName(string name)
        {
            CleanSendKeys(_inputName, name);
            return this;
        }

        public bool IsNameInvalid()
        {
            return !_errorMessage[0].GetAttribute("class").Contains("hide");
        }

        public RegisterPage SetLastname(string lastname)
        {
            _inputLastname.SendKeys(lastname);
            return this;
        }

        public bool IsLastnameInvalid()
        {
            return !_errorMessage[1].GetAttribute("class").Contains("hide");
        }

        public RegisterPage SetEmail(string email)
        {
            _inputEmail.SendKeys(email);
            return this;
        }

        public bool IsEmailInvalid()
        {
            return !_errorMessage[2].GetAttribute("class").Contains("hide");
        }

        public RegisterPage SetPassword(string password)
        {
            _inputPassword.SendKeys(password);
            return this;
        }

        public bool IsNoPasswordPopupDisplayed()
        {
            return !_noPasswordPopup.GetAttribute("class").Contains("u-hide");
        }

        public void ClickCreate()
        {
            ClickElement(_buttonCreate);
        }
    }
}