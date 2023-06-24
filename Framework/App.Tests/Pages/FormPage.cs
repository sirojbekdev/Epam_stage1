using NUnit.Framework.Internal;
using SeleniumExtras.PageObjects;

namespace App.Tests.Pages
{
    public class FormPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly string _numberOfInstances = "4";
        private readonly string _url = "https://cloud.google.com/products/calculator";
        private readonly string _email = "sampleapp@yopmail.com";


		public FormPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
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

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'n1-standard-8')]")]
        public IWebElement MachineType { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-checkbox[@ng-model='listingCtrl.computeServer.addGPUs']")]
        public IWebElement AddGpuCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='GPU type']")]
        public IWebElement GpuTypeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'NVIDIA Tesla V100')]")]
        public IWebElement GpuType { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Number of GPUs']")]
        public IWebElement GpuInstanceDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-option[@role='option' and @value='1' and contains(@ng-repeat,'gpuType')]")]
        public IWebElement GpuInstance { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Local SSD']")]
        public IWebElement LocalSsdDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'2x375 GB')]")]
        public IWebElement LocalSsd { get; set; }

        [FindsBy(How = How.XPath, Using = "(//md-select[@placeholder='Datacenter location' and @ng-model='listingCtrl.computeServer.location'])")]
        public IWebElement DatacenterDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-option[@id='select_option_254']/div")]
        public IWebElement Datacenter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//md-select[@placeholder='Committed usage'])[1]")]
        public IWebElement CommittedUsageDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//md-option[@id='select_option_134']")]
        public IWebElement CommittedUsage { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[contains(text(),'Add to Estimate')])[1]")]
        public IWebElement AddToEstimateButton { get; set; }


		public void FillForm()
        {
            _wait.Until(ExpectedConditions.UrlMatches(_url));
			var pageFrame = _wait.Until(ExpectedConditions.ElementToBeClickable(PageFrame));
			_driver.SwitchTo().Frame(PageFrame);
            var acccountFrame = _wait.Until(ExpectedConditions.ElementToBeClickable(FormFrame));
            _driver.SwitchTo().Frame(FormFrame);
            NumberOfInstancesInput.Clear();
            NumberOfInstancesInput.SendKeys(_numberOfInstances);
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
            DatacenterDropDown.SendKeys("Frankfurt" + Keys.Cancel);
            _wait.Until(ExpectedConditions.ElementToBeClickable(Datacenter));
            Datacenter.Click();
            CommittedUsageDropDown.Click();
            CommittedUsage.Click();
            AddToEstimateButton.Click();
		}

		[FindsBy(How = How.XPath, Using = "//button[@id='Email Estimate']")]
		public IWebElement EmailButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[@name='description' and @type='email']")]
		public IWebElement EmailInput { get; set; }

		[FindsBy(How = How.XPath, Using = "//button[contains(text(),'Send Email')]")]
		public IWebElement SendButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//div[contains(@class,'total')]/h2/b")]
		public IWebElement TotalCost { get; set; }
		

		public void SendResultEmail()
        {
			var tabs = _driver.WindowHandles;
			_driver.SwitchTo().Window(tabs[0]);
			_driver.SwitchTo().Frame(PageFrame);
			_driver.SwitchTo().Frame(FormFrame);
			_wait.Until(ExpectedConditions.ElementToBeClickable(EmailButton));
            EmailButton.Click();
			_driver.SwitchTo().ActiveElement();
			_wait.Until(ExpectedConditions.ElementToBeClickable(EmailInput));
			EmailInput.SendKeys(_email);
            SendButton.Click();
            TotalCost.Text.Substring(0, 22);

		}
	}
}
