using AutoFinalTaskCS.Drivers;
using AutoFinalTaskCS.Page;
using AutoFinalTaskCS.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace AutoFinalTaskCS.Test
{
    public class AccountTest
    {
        private static IWebDriver Driver = null!;
        private static AccountPage _accountPage = null!;
        private static WishlistPage _wishlistPage = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        [Test]
        public void TestRegister()
        {
            _accountPage = new AccountPage(Driver);
            _accountPage.GoToURL();
            _accountPage.Register();
            IWebElement signOutLink = Driver.FindElement(By.CssSelector("a[class='logout']"));
            var result = signOutLink.Text.ToString();

            Assert.AreEqual("Sign out", result, "Login failed.");
        }

        [Test]
        public void TestLogin()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();
            IWebElement signOutLink = Driver.FindElement(By.CssSelector("a[class='logout']"));
            var result = signOutLink.Text.ToString();

            Assert.AreEqual("Sign out", result, "Login failed.");
        }

        [Test]
        public void TestWishlistAutoCreation()
        {
            _wishlistPage = new WishlistPage(Driver);
            _wishlistPage.GoToURL();
            _wishlistPage.AddItemToWishlist();
            
            // not finished yet
        }

        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotTool.MakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}