using SeleniumExtras.PageObjects;

namespace App.Tests.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly string _url = "https://cloud.google.com/ ";
        private readonly string _numberOfInstances = "4";

        public SearchPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='q']")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[@class='gs-title']/b[text()='Google Cloud Pricing Calculator'])[1]")]
        public IWebElement SearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='input_95']")]
        public IWebElement NumberOfInstancesInput { get; set; }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void Search(string textToType)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(SearchBox));
            SearchBox.Clear();
            SearchBox.SendKeys(textToType + Keys.Enter);
            _wait.Until(ExpectedConditions.ElementToBeClickable(SearchResult)).Click();

        }

    }
}
