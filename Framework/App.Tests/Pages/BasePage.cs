using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Tests.Pages
{
	public abstract class BasePage
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
			_driver = driver;
			_wait = wait;
			PageFactory.InitElements(_driver, this);
		}
    }
}
