using POM_Basic.Source.Drivers;
using POM_Basic.Source.Pages;
namespace POM_Basic.Tests
{
    [TestFixture]
    public class HomeTest :Driver
    {
        //private IWebDriver _driver;

        [Test]
        public void SearchBook()
        {

            HomePage homePage = new HomePage();
            homePage.LaunchUrl();
            Assert.True(_driver.Title.Contains("BookCart"));
        }
    }
}
