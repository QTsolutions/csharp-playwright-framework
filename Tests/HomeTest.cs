using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM_Basic.Source.Drivers;
using POM_Basic.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
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
