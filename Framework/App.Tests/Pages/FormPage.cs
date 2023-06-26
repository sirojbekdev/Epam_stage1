using App.Tests.Models;
using SeleniumExtras.PageObjects;
#nullable disable

namespace App.Tests.Pages
{
    public class FormPage : BasePage
    {
		private readonly EngineData _engineData;
        private readonly string _url = "https://cloud.google.com/products/calculator";


		public FormPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            PageFactory.InitElements(_driver, this);
			_engineData = DataReader.GetSection<EngineData>("../../../data.json", nameof(EngineData));
		}

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@name,'goog')]")]
        public IWebElement PageFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='myFrame']")]
        public IWebElement FormFrame { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='quantity' and @ng-model='listingCtrl.computeServer.quantity']")]
        public IWebElement NumberOfInstancesInput { get; set; }

        [FindsBy(How =How.XPath, Using = "//div[contains(text(),'N1')]")]
        public IWebElement Series { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@name='series']")]
        public IWebElement SeriesDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Instance type']")]
		public IWebElement MachineTypeDropDown { get; set; }

        public IWebElement MachineType => _driver.FindElement( 
            By.XPath($"//div[contains(text(),'{_engineData.InstanceType}')]"));

        [FindsBy(How = How.XPath, Using = "//md-checkbox[@ng-model='listingCtrl.computeServer.addGPUs']")]
        public IWebElement AddGpuCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='GPU type']")]
        public IWebElement GpuTypeDropDown { get; set; }

        public IWebElement GpuType => _driver.FindElement(By.XPath($"//div[contains(text(),'{_engineData.GPUType}')]"));

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Number of GPUs']")]
        public IWebElement GpuInstanceDropDown { get; set; }

        public IWebElement GpuInstance => _driver.FindElement(By.XPath($"//md-option[@role='option' and @value='{_engineData.NumberOfGPUs}' and contains(@ng-repeat,'gpuType')]"));

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Local SSD']")]
        public IWebElement LocalSsdDropDown { get; set; }

        public IWebElement LocalSsd => _driver.FindElement(By.XPath($"//div[contains(text(),'{_engineData.LocalSSD}')]"));

		[FindsBy(How = How.XPath, Using = "(//md-select[@placeholder='Datacenter location' and @ng-model='listingCtrl.computeServer.location'])")]
        public IWebElement DatacenterDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-option[@id='select_option_254']/div")]
        public IWebElement Datacenter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//md-select[@placeholder='Committed usage'])[1]")]
        public IWebElement CommittedUsageDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "select_option_134")]
        public IWebElement CommittedUsage { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[contains(text(),'Add to Estimate')])[1]")]
        public IWebElement AddToEstimateButton { get; set; }


		// Send Rusult

		[FindsBy(How = How.XPath, Using = "//button[@id='Email Estimate']")]
		public IWebElement EmailButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[@name='description' and @type='email']")]
		public IWebElement EmailInput { get; set; }

		[FindsBy(How = How.XPath, Using = "//button[contains(text(),'Send Email')]")]
		public IWebElement SendButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//div[contains(@class,'total')]/h2/b")]
		public IWebElement TotalCost { get; set; }

		public string Estimate()
        {
            _wait.Until(ExpectedConditions.UrlMatches(_url));
			_wait.Until(ExpectedConditions.ElementToBeClickable(PageFrame));
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click()", PageFrame);
            _driver.SwitchTo().Frame(PageFrame);
			_wait.Until(ExpectedConditions.ElementToBeClickable(FormFrame));
			Thread.Sleep(1000);
			js.ExecuteScript("arguments[0].click()", FormFrame);
            _driver.SwitchTo().Frame(FormFrame);
			NumberOfInstancesInput.Clear();
            NumberOfInstancesInput.SendKeys(_engineData.NumberOfInstances.ToString());
            SeriesDropDown.Click();
            Series.Click();
            MachineTypeDropDown.Click();
            MachineType.Click();
            AddGpuCheckbox.Click();
            GpuTypeDropDown.Click();
            GpuType.Click();
            GpuInstanceDropDown.Click();
            GpuInstance.Click();
            LocalSsdDropDown.Click();
            LocalSsd.Click();
            DatacenterDropDown.Click();
            DatacenterDropDown.SendKeys(_engineData.DatacenterLocation + Keys.Cancel);
            _wait.Until(ExpectedConditions.ElementToBeClickable(Datacenter));
            Datacenter.Click();
            CommittedUsageDropDown.Click();
            CommittedUsage.Click();
            AddToEstimateButton.Click();

			string totalCostText = TotalCost.Text;
			string[] splitWords = totalCostText.Split(' ');
			string cost = splitWords[4];

			return cost;
		}

		public void SendResultEmail(string email)
        {
			var tabs = _driver.WindowHandles;
			_driver.SwitchTo().Window(tabs[0]);
			_driver.SwitchTo().Frame(PageFrame);
			_driver.SwitchTo().Frame(FormFrame);
			
			_wait.Until(ExpectedConditions.ElementToBeClickable(EmailButton));
            EmailButton.Click();
			_driver.SwitchTo().ActiveElement();
			_wait.Until(ExpectedConditions.ElementToBeClickable(EmailInput));
			EmailInput.SendKeys(email);
            SendButton.Click();
		}
	}
}
