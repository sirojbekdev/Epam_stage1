using OpenQA.Selenium;

namespace App.Test
{
    public class SendMailTests
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
        public void SendMailTest()
        {
            var sentMessage = "This is a simple text message";
            Driver.Url = "https://mail.google.com";
            Driver.FindElement(By.CssSelector("#identifierId")).SendKeys("fmailone111@gmail.com");
            Driver.FindElement(By.CssSelector("#identifierNext")).Click();

            var passwordInput1 = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Passwd']")));
            passwordInput1.SendKeys("Pass123!");
            Driver.FindElement(By.CssSelector("#passwordNext")).Click();

            Wait.Until(ExpectedConditions.UrlMatches("https://mail.google.com/mail/u/0/#inbox"));

            Driver.FindElement(By.XPath("//div[@class='T-I T-I-KE L3' and @role='button']")).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var toInput = By.XPath("//div[@role='presentation']/input");
            //Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@class='agP aFw']")));
            Click(toInput);
            Driver.FindElement(toInput).SendKeys("fmailtwo222@gmail.com");

            Driver.FindElement(By.XPath("//div[@class='Am Al editable LW-avf tS-tW']"))
                .SendKeys(sentMessage);

            Driver.FindElement(By.XPath("//div[@role='button' and text()='Send']")).Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='Message sent']")));


            Driver.FindElement(By.XPath("//a[@class='gb_e gb_1a gb_s' and @role='button']")).Click();

            var acccountFrame = Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//iframe[@name='account']")));
            Driver.SwitchTo().Frame("account");
            Driver.FindElement(By.XPath("//a[@class='V5tzAf h2rKjc jFfZdd OtBgcb']")).Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //Driver.Manage().Timeouts().

            var account2 = By.XPath("(//div[@role='link'])[2]");
            Click(account2);
            Wait.Until(ExpectedConditions.ElementToBeClickable(account2)).Click();


            var emailInput2 = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#identifierId")));
            emailInput2.SendKeys("fmailtwo222@gmail.com");
            Click(By.CssSelector("#identifierNext"));

            var passwordInput2 = FindElement(By.XPath("//input[@name='password']"));
            passwordInput2.SendKeys("Pass123!");
            Click(By.CssSelector("#passwordNext"));

            var latestMessage = By.XPath("//table[@role='grid']/tbody/tr[1]");
            Click(latestMessage);
            var messageDiv = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@dir='ltr'])[last()]")));
            var message = messageDiv
                .GetAttribute("innerText");

            Assert.That(message, Is.EqualTo(sentMessage));

            var replyBtn = By.XPath("//span[text()='Reply' and @role='link']");
            Click(replyBtn);

            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='textbox']"))).SendKeys("This is a response");
            Click(By.XPath("//div[@role='button' and text()='Send']"));
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='Message sent']")));

        }

        private bool Click(By by)
        {
            bool status = false;
            int i = 0;
            while (i == 0)
                try
                {
                    Driver.FindElement(by).Click();
                    status = true;
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                }
            return status;
        }

        private IWebElement? FindElement(By by)
        {
            int i = 0;
            while (i == 0)
            {
                try
                {
                    return Driver.FindElement(by);
                }
                catch (StaleElementReferenceException e)
                {
                }
            }
            return null;
        }
    }
}