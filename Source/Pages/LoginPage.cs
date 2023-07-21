using OpenQA.Selenium;
using POM_Basic.Source.Drivers;
using POM_Basic.Utilities;
using SeleniumExtras.PageObjects;

namespace POM_Basic.Source.Pages
{
    public class LoginPage : Driver
    {
        ReadJson json = new ReadJson();

        public LoginPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        //Declaration of Locators
        [FindsBy(How = How.Id, Using = "mat-input-0")] private IWebElement _txtUserName;
        [FindsBy(How = How.Id, Using = "mat-input-1")] private IWebElement _txtPassword;
        [FindsBy(How = How.XPath, Using = "(//*/span[text()='Login'])[2]")] private IWebElement _btnLogin;
        [FindsBy(How = How.XPath, Using = "//h3[text()='Login']")] private IWebElement _loginHeader;
        [FindsBy(How = How.Id, Using = "mat-error-0")] private IWebElement _alertMessage;


        //Action Methods
        public async Task Login_With_Invalid_Credentials()                                //Enter the login Credentials
        {
            _txtUserName.SendKeys(json.ReadData("invalidUserName"));
            _txtPassword.SendKeys(json.ReadData("invalidPassword"));
            _btnLogin.Click();
            Thread.Sleep(2000);
        }
        public async Task Login_With_Correct_Credentials()                                //Enter the login Credentials
        {
            _txtUserName.SendKeys(json.ReadData("validUserName"));
            _txtPassword.SendKeys(json.ReadData("validPassword"));
            _btnLogin.Click();
        }
        public Boolean LoginHeader()
        {
            return _loginHeader.Displayed;                  //Verify that login header is visible
        }
        public Boolean AlertMessage()                                                  //Verify that Alert message is visible
        {
            Console.WriteLine("The " + _alertMessage.ToString);
            return _alertMessage.Displayed;
        }
    }
}
