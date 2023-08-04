using POM_Basic.Source.Drivers;
using POM_Basic.Utilities;

namespace POM_Basic.Tests
{
    public class LoginTest : Driver
    {
        ReadJson json = new ReadJson();

        [Test]
        public async Task Login_Should_Not_Be_Success()
        {
            //Test Execution Flow steps
            homepage.LaunchUrl();
            await homepage.Click_On_Login_Button();                                        //Click on the login button on the top right
            await loginpage.Login_With_Invalid_Credentials();                         //Enter the credentials on the login page

            Assert.IsTrue(loginpage.AlertMessage());                      //Verify that incorrect cresentials message is visible.
        }

        [Test]
        public async Task Login_Should_Be_Success()
        {

            //Test Execution Flow steps
            homepage.LaunchUrl();

            await homepage.Click_On_Login_Button();                                     //Click on the login button on the top right
            await loginpage.Login_With_Correct_Credentials();                                         //Enter the valid credentials on the login page

            homepage.Enter_Book_Name_And_Select_Book("Roomies");                //Enter the book name in the search bar
            Assert.IsTrue(homepage.Cart_Count_Is_Zero());

            homepage.Click_On_Add_To_Cart_Button();                                //Add Book to the Cart

            var isNonZero = homepage.CartCountIsNotZero();             //Creating a variable for the assertion
            Assert.IsTrue(isNonZero);                                        //Verify that cart number is greater than zero

            await cartItemsPage.ClickOnCart();
            Assert.IsTrue(cartItemsPage.CartItemsHeader());

            cartItemsPage.ClickOnClearCart();

            Assert.IsTrue(cartItemsPage.Shopping_Cart_Is_Empty_Header_Is_Visible());

            cartItemsPage.Click_On_Continue_Shopping_Button();
            Assert.IsTrue(homepage.Cart_Count_Is_Zero());

            await homepage.ClickLogOut();                                    //Click on the Logout Button
            Assert.IsTrue(loginpage.LoginHeader());                    //Verify that the User lands on the Login Page
        }

        [Test]
        public async Task Login_With_Api()
        {
            //Test Execution Flow steps
            homepage.LaunchUrl();

            await homepage.Click_On_Login_Button();
            await loginTestApi.AuthenticateTest(json.ReadData("postApiEndPoint"), 
                    JsonUtility.ReadAndDeserialize("username", "password"));

            await loginTestApi.GetShoppingCart(json.ReadData("shoppingCartApiEndPoint"));
            await loginTestApi.AddToCart(json.ReadData("addToCartApiEndPoint"));
        }

    }
}
