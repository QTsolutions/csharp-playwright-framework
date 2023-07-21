using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POM_Basic.Source.Drivers;
using POM_Basic.Utilities;
using SeleniumExtras.PageObjects;


namespace POM_Basic.Source.Pages
{
    public class HomePage : Driver
    {
        ReadJson json = new ReadJson();

        public HomePage()
        {
            PageFactory.InitElements(_driver, this);
        }

        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
        //Declaration of Locators
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Login')]")] private IWebElement _lnkLogin;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search books or authors']")] private IWebElement _searchBar;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Roomies')]")] private IWebElement _bookIem;
        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(),'Add to Cart')]")] private IWebElement _addToCart;
        [FindsBy(How = How.Id, Using = "mat-badge-content-0")] private IWebElement _cartCount;
        [FindsBy(How = How.XPath, Using = "//button/*/*[text()='arrow_drop_down']")] private IWebElement _userDropDown;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Logout')]")] private IWebElement _lnkLogout;


        // Action Methods
        public async void LaunchUrl()
        {
            _driver.Navigate().GoToUrl(json.ReadData("url"));
        }
        public async Task Click_On_Login_Button() => _lnkLogin.Click();                                 //Click on Header Login
        public void Enter_Book_Name_And_Select_Book(string bookname)
        {
           
            // fluentWait.Timeout = TimeSpan.FromSeconds(5);
            // fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            // IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath("//input[@placeholder='Search books or authors']")));
            Thread.Sleep(2000);
            _searchBar.SendKeys(bookname);                                             //Enter the book name in the search bar
            Thread.Sleep(2000);
            _bookIem.Click();
        }

        public Boolean Cart_Count_Is_Zero()
        {
            Thread.Sleep(2000);
            string cartCount = _cartCount.Text;
            int num = Int32.Parse(cartCount);
            return num == 0;
        }
        public void Click_On_Add_To_Cart_Button()
        {
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath("//button/span[contains(text(),'Add to Cart')]")));
            _addToCart.Click();                                                        //Click on Add to cart Button
        }
        public Boolean CartCountIsNotZero()                                            //Verify that cart count is not zero
        {
            Thread.Sleep(2000);
            string cartCount = _cartCount.Text;
            Console.WriteLine("There are " + cartCount + " books added in the cart.");
            int num = Int32.Parse(cartCount);
            return num > 0;
        }
        public async Task ClickLogOut()                                                //Click on the Logout button
        {
            _userDropDown.Click();
            _lnkLogout.Click();
        }
    }
}
