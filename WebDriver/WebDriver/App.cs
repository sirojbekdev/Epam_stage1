using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;

namespace WebDriver
{
    [TestFixture]
    public class App
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        [SetUp]
        public void SetupTest()
        {
            Driver = new FirefoxDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }
        [TearDown]
        public void TeardownTest()
        {
            Driver.Quit();
        }
        [Test]
        public void SearchTextInSearchEngine_Second()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.Url = "https://mail.google.com";
            Driver.FindElement(By.CssSelector("#Email")).SendKeys("fmailone111@gmail.com");
            Driver.FindElement(By.CssSelector("#next")).Click();

            var SearchResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#Passwd")));
            SearchResult.SendKeys("Pass123!");
            Driver.FindElement(By.CssSelector("#signIn")).Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Assert.AreEqual("https://mail.google.com/mail/u/0/#inbox", Driver.Url);

        }
    }
}