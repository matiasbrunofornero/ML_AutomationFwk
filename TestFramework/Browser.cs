using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
#pragma warning disable CS0618 // Type or member is obsolete

namespace TestFramework
{
    public class Browser
    {
        const string path = @"C:\Selenium\";
        static IWebDriver webDriver = new FirefoxDriver(path);

        private IWebDriver driver;
        private WebDriverWait wait;

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public static void SetUp()
        {
            webDriver = GetWebDriver();
            webDriver.Manage().Window.Maximize();
        }

        public static IWebDriver GetWebDriver()
        {
            return webDriver;
        }

        public static string GetTitle()
        {
            return webDriver.Title;
        }

        public static void CleanData()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void GoTo(string url)
        {
            webDriver.Url = url;
        }

        public static void Close()
        {
            webDriver.Close();
        }

        protected void CleanSendKeys(IWebElement element, String text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Clear();
            element.SendKeys(text);
        }

        protected void ClickElement(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }
    }
}
