using App.Tests.DriverManager;
#nullable disable
namespace App.Tests
{
	public abstract class BaseTest
	{
		public IWebDriver Driver { get; set; }
		public WebDriverWait Wait { get; set; }
		public WebDriverManager WebDriverManager { get; set; }
		[OneTimeSetUp]
		public void Setup()
		{
			WebDriverManager = new("chrome");
			Driver = WebDriverManager.Driver;
			Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
		}

		[OneTimeTearDown]
		public void Teardown()
		{
			WebDriverManager.TakeScreenShot();
			WebDriverManager.Close();
		}
	}
}