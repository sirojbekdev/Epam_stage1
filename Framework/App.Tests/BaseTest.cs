namespace App.Tests
{
	public abstract class BaseTest
	{
		public IWebDriver Driver { get; set; }
		public WebDriverWait Wait { get; set; }
		[SetUp]
		public void Setup()
		{
			Driver = new ChromeDriver();
			Driver.Manage().Window.Maximize();
			Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
		}
	}
}