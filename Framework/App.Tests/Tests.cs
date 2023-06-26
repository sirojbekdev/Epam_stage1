using App.Tests.Pages;

namespace App.Tests
{
    public class Tests : BaseTest
    {
        private readonly string _searchText = "Google Cloud Platform Pricing Calculator";

        [Test]
        public void Estimate_Test()
        {
            SearchPage searchPage = new(Driver,Wait);
            FormPage formPage = new(Driver, Wait);
            MailPage mailPage = new(Driver, Wait);

			searchPage.Navigate();
			searchPage.Search(_searchText);
            var expected = formPage.Estimate();

            var email = mailPage.EnterToMail();
            formPage.SendResultEmail(email);
            var result = mailPage.CheckResultMail();

			Assert.That(result+"gw", Is.EqualTo(expected));
        }
    }
}