
using OpenQA.Selenium;
using POM_Basic.Source.Drivers;
using SeleniumExtras.PageObjects;

namespace POM_Basic.Source.Pages
{
     public class CartItemsPage : Driver
     {
        public CartItemsPage()
        {
            PageFactory.InitElements(_driver, this);
        }

         //Declaration of Locators

        [FindsBy(How = How.XPath, Using = "//span//*[@id='mat-badge-content-0']/ancestor::span")] private IWebElement _cartButton;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Clear cart')]")] private IWebElement _clearCartButton;
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Cart Items')]")] private IWebElement _CartItemHeader;
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),' Shopping cart is empty ')]")] private IWebElement _ShoppingCartIsEmptyHeader;
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Continue shopping')]")] private IWebElement _continueShoppingButton;
        
        

         // Action Methods
        public bool CartItemsHeader()
        {
            return _CartItemHeader.Displayed;
        } 
        public Task ClickOnCart()
        {
            _cartButton.Click();
            return Task.CompletedTask;
        }

        public void ClickOnClearCart()
        {
            Thread.Sleep(2000);
            _clearCartButton.Click();
        }

        public bool Shopping_Cart_Is_Empty_Header_Is_Visible()
        {
            Thread.Sleep(2000);
            return _ShoppingCartIsEmptyHeader.Displayed;
        }

        public void Click_On_Continue_Shopping_Button()
        {
            _continueShoppingButton.Click();
        }
    }
     
}
