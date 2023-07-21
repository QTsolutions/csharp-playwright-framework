using OpenQA.Selenium;
using POM_Basic.Source.Drivers;
using POM_Basic.Source.Pages;
using Microsoft.Playwright;
using NUnit;
using FluentAssertions;
using System.Text.Json;
using POM_Basic.Utilities;

namespace POM_Basic.Tests
{

    public class LoginTestApi : Driver
    {
         ReadJson json = new ReadJson();
       
        [Test]
        [Fact]
        public async Task GetRequest()
        {
            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                 BaseURL = json.ReadData("url")
            });
            var response = await requestContext.GetAsync(json.ReadData("getAllBookApiEndPoint"));
            var jsonElement = await response.JsonAsync();
            Console.WriteLine(jsonElement);
        }

        [Test]
        [Fact]
        public async Task AuthenticateTest()
        {
            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = json.ReadData("url"),
                IgnoreHTTPSErrors = true
            });
            Console.WriteLine(requestContext);

            var response = await requestContext.PostAsync(json.ReadData("postApiEndPoint"), new APIRequestContextOptions
            {
                DataObject = new
                {
                    username = json.ReadData("validUserName"),
                    password = json.ReadData("validPassword")
                }
            });

            var jsonString = await response.JsonAsync();
            Console.WriteLine(jsonString);

            var authenticationResponse = jsonString.Value.Deserialize<Authenticate>();
            authenticationResponse?.token.Should().NotBe(String.Empty);
        }

        [Test]
        [Fact]
        public async Task AddToCart()
        {
            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = json.ReadData("url"),
                IgnoreHTTPSErrors = true
            });
            Console.WriteLine(requestContext);

            var response = await requestContext.PostAsync(json.ReadData("addToCartApiEndPoint"));

            var jsonString = await response.JsonAsync();
            Console.WriteLine(jsonString);
        }

        [Fact]
        private async Task<string?> GetToken()
        {
            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = json.ReadData("url"),
                IgnoreHTTPSErrors = true
            });

            var response = await requestContext.PostAsync(json.ReadData("postApiEndPoint"), new APIRequestContextOptions
            {
                DataObject = new
                {
                    username = json.ReadData("validUserName"),
                    password = json.ReadData("validPassword")
                }
            })!;

            var jsonString = await response.JsonAsync();

            return jsonString?.Deserialize<Authenticate>()?.token;
        }

        [Test]
        [Fact]
        public async Task GetShoppingCart()
        {
            var token = await GetToken();

            var playwright = await Playwright.CreateAsync();
            var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = json.ReadData("url"),
                IgnoreHTTPSErrors = true
            });

            var response = await requestContext.GetAsync(json.ReadData("shoppingCartApiEndPoint"), new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
                 {
                    {"Authorization", $"Bearer {token}"}
                 }
            })!;

            var data = await response.JsonAsync();
            Console.WriteLine(data);
        }


        private record Authenticate(string token) { }

        internal class FactAttribute : Attribute
        { }
    }
}

