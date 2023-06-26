using SeleniumExtras.PageObjects;

namespace App.Tests.Pages
{
	public abstract class BasePage
	{
		protected IWebDriver _driver;
		protected WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
			_driver = driver;
			_wait = wait;
			PageFactory.InitElements(_driver, this);
		}
    }
}
