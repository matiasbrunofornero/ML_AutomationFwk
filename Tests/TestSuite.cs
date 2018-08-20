using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestFramework;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver webDriver = Browser.GetWebDriver();

        [TestInitialize]
        public void GoToHomePage()
        {
            HomePage homePage = new HomePage(webDriver);

            Browser.CleanData();
            Browser.SetUp();

            homePage.GoTo();

            Assert.AreEqual("https://www.mercadolibre.com.ar/", homePage.GetActualUrl());
        }

        [TestMethod]
        public void Search()
        {
            HomePage homePage = new HomePage(webDriver);
            ResultsPage resultsPage = new ResultsPage(webDriver);
            ResultSummary summaryPage = new ResultSummary(webDriver);

            resultsPage = homePage.SetSearch("iPhone 8 Plus 64 GB", webDriver);
            summaryPage = resultsPage.ClickResult(2, webDriver);
        }

        [TestMethod]
        public void Login()
        {
            HomePage homePage = new HomePage(webDriver);
            LoginPage loginPage = new LoginPage(webDriver);
            PasswordPage passwordPage = new PasswordPage(webDriver);

            loginPage = homePage.ClickLogin(webDriver);
            passwordPage = loginPage.SetUsername("matiasbrunofornero@gmail.com", webDriver);

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
