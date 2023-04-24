namespace App.Test
{
    public class RenameTests
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
        public void Rename()
        {
            var sentMessage = "This is a simple text message";
            Driver.Url = "https://mail.google.com";
            Driver.FindElement(By.CssSelector("#identifierId")).SendKeys("fmailone111@gmail.com");
            Driver.FindElement(By.CssSelector("#identifierNext")).Click();

            var passwordInput1 = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Passwd']")));
            passwordInput1.SendKeys("Pass123!");
            Driver.FindElement(By.CssSelector("#passwordNext")).Click();

            Wait.Until(ExpectedConditions.UrlMatches("https://mail.google.com/mail/u/0/#inbox"));


            Driver.FindElement(By.XPath("//a[@class='gb_e gb_1a gb_s' and @role='button']")).Click();

            var acccountFrame = Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//iframe[@name='account']")));
            Driver.SwitchTo().Frame("account");

            Click(By.XPath("//a[text()='Manage your Google Account']"));

            var tabs = Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs[1]);

            var personalInfoTab = By.XPath("(//div[text()='Personal info']/./parent::a)[1]");
            Wait.Until(ExpectedConditions.ElementToBeClickable(personalInfoTab));
            Click(personalInfoTab);

            var nameBtn = By.XPath("//div[text()='Name']");
            Wait.Until(ExpectedConditions.ElementToBeClickable(nameBtn));
            Click(nameBtn);

            var editNameBtn = By.XPath("//button[@aria-label='Edit Name']");
            Wait.Until(ExpectedConditions.ElementExists(editNameBtn));
            Click(editNameBtn);

            var nameInputPath = By.XPath("(//input[@type='text'])[2]");
            var firstName = Wait.Until(ExpectedConditions.ElementToBeClickable(nameInputPath));
            firstName.Clear();
            firstName.SendKeys("New");

            var lastName = Driver.FindElement( By.XPath("(//input[@type='text'])[2]"));
            lastName.Clear();
            lastName.SendKeys("One");


            Click(By.XPath("//button/span[text()='Save']"));

            var newFullName = Wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[text()='Name']/following::div[1]"))).GetAttribute("innerText");

            var expected = "New One";

            Assert.That(newFullName, Is.EqualTo(expected));



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
    }
}
