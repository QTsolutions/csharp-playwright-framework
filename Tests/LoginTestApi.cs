using POM_Basic.Source.Drivers;
using Microsoft.Playwright;
using FluentAssertions;
using System.Text.Json;
using POM_Basic.Utilities;

namespace POM_Basic.Tests
{

    public class LoginTestApi : Driver
    {
        ReadJson json = new ReadJson();

        [Test]
        [TestCase("getAllBookApiEndPoint")]
        public async Task GetRequest(string endPoint)
        {
            await loginpage.CreateApiContext();

            var response = await loginpage.ApiRequestContext?.GetAsync(endPoint)!;
            var jsonElement = await response.JsonAsync();
            Console.WriteLine(jsonElement);
        }

        [Test]
        [TestCase("postApiEndPoint", "payload")]
        public async Task AuthenticateTest(string endPoint, object payload)
        {
            await loginpage.CreateApiContext();

            var response = await loginpage.ApiRequestContext?.PostAsync(endPoint, new APIRequestContextOptions
            {
                DataObject = payload
            })!;

            var jsonString = await response.JsonAsync();
            Console.WriteLine(jsonString);

            var authenticationResponse = jsonString.Value.Deserialize<Authenticate>();
            authenticationResponse?.token.Should().NotBe(String.Empty);
        }

        [Test]
        [TestCase("addToCartApiEndPoint")]
        public async Task AddToCart(string endPoint)
        {
            await loginpage.CreateApiContext();

            var response = await loginpage.ApiRequestContext?.PostAsync(endPoint)!;

            var jsonString = await response.JsonAsync();
            Console.WriteLine(jsonString);

            string quantityValueOld = json.ReadQuantityJson("Quantity");
            int quantityValueInt = int.Parse(quantityValueOld);

            int quantityValueNew = int.Parse(jsonString.ToString()!);
            Console.WriteLine("Quantity Value (New Method): " + quantityValueNew);

            Assert.AreEqual(quantityValueInt + 1, quantityValueNew);
        }

        [Test]
        [TestCase("shoppingCartApiEndPoint")]
        public async Task GetShoppingCart(string endPoint)
        {
             await loginpage.CreateApiContext();

            var response = await loginpage.ApiRequestContext?.GetAsync(endPoint)!;
            var jsonElement = await response.JsonAsync();
            Console.WriteLine(jsonElement);

            byte[] responseBody = await response.BodyAsync();

            // Parse the JSON byte array to a JsonDocument.
            using var document = JsonDocument.Parse(responseBody);
            
            int quantityValue;
            
            //convert the jsonElement into string
            if(jsonElement.ToString()!.Equals("[]"))
            {
                quantityValue = 0;
            }else{
                // Access the first item in the JSON array (if it's an array).
                quantityValue = document.RootElement.EnumerateArray().FirstOrDefault().GetProperty("quantity").GetInt32();
            
            }
            //write the value in the json file
            JsonUtility.SerializeAndWrite(quantityValue.ToString());
        }

        //record is an immutable data type with read-only properties 
        private record Authenticate(string token) { }

    }
}

