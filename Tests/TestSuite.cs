using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using TestFramework;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        String Url = "https://www.mercadolibre.com.ar/";
        IWebDriver webDriver = Browser.GetWebDriver();

        [TestInitialize]
        public void GoToHomePage()
        {
            Browser.SetUp();
            Browser.CleanData();

            HomePage homePage = new HomePage(webDriver);
            homePage.GoTo(Url);

            Assert.IsTrue(homePage.IsAt());
        }

        [TestMethod]
        public void Search()
        {
            HomePage homePage = new HomePage(webDriver);

            homePage.SetSearch("iPhone 8 Plus 64 GB");
        }

        [TestMethod]
        public void Login()
        {
            IWebDriver webDriver = Browser.GetWebDriver();

            HomePage homePage = new HomePage(webDriver);
            homePage.ClickLogin(webDriver);

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.SetUsername("matiasbrunofornero@gmail.com", webDriver);

            PasswordPage passwordPage = new PasswordPage(webDriver);
            passwordPage.SetPassword("dni36616668");
            passwordPage.ClickAccept();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }

}
