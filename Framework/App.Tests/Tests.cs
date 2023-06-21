using App.Tests.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace App.Tests
{
    public class Tests : BaseTest
    {
        private readonly string _searchText = "Google Cloud Platform Pricing Calculator";

        [Test]
        public void Estimate_Test()
        {
            SearchPage searchPage = new(Driver,Wait);
			searchPage.Navigate();
			searchPage.Search(_searchText);
            FormPage formPage = new(Driver, Wait);
            formPage.FillForm();

            MailPage mailPage = new(Driver, Wait);
            mailPage.EnterToMail();

            formPage.SendResultEmail();
        }
    }
}