using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static System.Net.WebRequestMethods;

namespace App.Tests.Pages
{
	public class MailPage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;

		private const string _mailServer = "https://yopmail.com/";
		private const string _email = "sampleapp@yopmail.com";


		public MailPage(IWebDriver driver, WebDriverWait wait)
        {
			_driver = driver;
			_wait = wait;
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.XPath, Using = "//input[@id='login']")]
		public IWebElement EmailInput { get; set; }

		public void EnterToMail()
		{
			_driver.SwitchTo().NewWindow(WindowType.Tab);
			_driver.Navigate().GoToUrl(_mailServer);
			EmailInput.SendKeys(_email + Keys.Enter);
		}
    }
}
