using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace App.Tests.DriverManager
{
	public class WebDriverManager
	{
		private IWebDriver _driver;
		public IWebDriver Driver { get { return _driver; } }

        public WebDriverManager(string browser)
        {
			_driver = browser.ToLower() switch
			{
				"chrome" => new ChromeDriver(),
				"firefox" => new FirefoxDriver(),
				"edge" => new EdgeDriver(),
				_ => throw new ArgumentException($"Browser '{browser}' is not supported"),
			};
			_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
		}

        public void TakeScreenShot()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
				var filepath = AppDomain.CurrentDomain.BaseDirectory + $"//screenshot.png";
				screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Png);
				TestContext.AddTestAttachment(filepath, "Screenshot of failed test");
			}
		}

		public void Close()
		{
			_driver.Quit();
		}
	}
}
