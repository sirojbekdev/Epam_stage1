namespace App.Test
{
    public class LoginTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        //[TearDown]
        //public void TeardownTest()
        //{
        //    Driver.Quit();
        //}

        [Test]
        public void ValidLoginTest()
        {
            Driver.Url = "https://mail.google.com";
            Driver.FindElement(By.CssSelector("#identifierId")).SendKeys("fmailone111@gmail.com");
            Driver.FindElement(By.CssSelector("#identifierNext")).Click();

            var passwordInput = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Passwd']")));
            passwordInput.SendKeys("Pass123!");
            Driver.FindElement(By.CssSelector("#passwordNext")).Click();

            Wait.Until(ExpectedConditions.UrlMatches("https://mail.google.com/mail/u/0/#inbox"));

            Assert.That(Driver.Url, Is.EqualTo("https://mail.google.com/mail/u/0/#inbox"));
        }

        [Test]
        public void LoginWithWrongEmailTest()
        {
            Driver.Url = "https://mail.google.com";
            Driver.FindElement(By.CssSelector("#identifierId")).SendKeys("femailOne1111@gmail.com");
            Driver.FindElement(By.CssSelector("#identifierNext")).Click();

            var errorMessage = Wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[text()='Couldn’t find your Google Account']")));

            Assert.IsNotNull(errorMessage);
        }
    }
}
