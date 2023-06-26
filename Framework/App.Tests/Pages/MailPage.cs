using SeleniumExtras.PageObjects;
#nullable disable

namespace App.Tests.Pages
{
	public class MailPage : BasePage
	{
		private const string _mailServer = "https://yopmail.com/";


		public MailPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//a[@href='email-generator' and contains(text(),'Random')]")]
		public IWebElement EmailGenerateButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//div[@id='geny']")]
		public IWebElement GeneratedEmail { get; set; }

		[FindsBy(How = How.XPath, Using = "//button/span[contains(text(),'Check Inbox')]")]
		public IWebElement EnterInbox { get; set; }

		[FindsBy(How = How.XPath, Using = "//iframe[@id='ifmail']")]
		public IWebElement InboxFrame { get; set; }

		[FindsBy(How = How.XPath, Using = "(//h3)[2]")]
		public IWebElement Cost { get; set; }


		public string EnterToMail()
		{
			_driver.SwitchTo().NewWindow(WindowType.Tab);
			_driver.Navigate().GoToUrl(_mailServer);
			EmailGenerateButton.Click();
			var email = GeneratedEmail.Text;
			EnterInbox.Click();

			return email;
		}

		public string CheckResultMail()
		{
			var tabs = _driver.WindowHandles;
			_driver.SwitchTo().Window(tabs[1]);
			_driver.Navigate().Refresh();
			Thread.Sleep(1500);
			_driver.Navigate().Refresh();
			_driver.SwitchTo().Frame(2);

			string costText = Cost.Text;
			string[] splitText = costText.Split(' ');
			string cost = splitText[1];

			return cost;
		}
    }
}
