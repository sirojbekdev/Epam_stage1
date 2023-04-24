//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

namespace App
{
    public class Program
    {
        //IWebDriver Driver = new ChromeDriver();
        //WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        //public string Login()
        //{
        //    Driver.Url = "https://mail.google.com";
        //    Driver.FindElement(By.CssSelector("#identifierId")).SendKeys("fmailone111@gmail.com");
        //    Driver.FindElement(By.CssSelector("#identifierNext")).Click();

        //    var SearchResult = Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Passwd']")));
        //    SearchResult.SendKeys("Pass123!");
        //    Driver.FindElement(By.CssSelector("#passwordNext")).Click();

        //    //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    Wait.Until(ExpectedConditions.UrlMatches("https://mail.google.com/mail/u/0/#inbox"));
        //}

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}
