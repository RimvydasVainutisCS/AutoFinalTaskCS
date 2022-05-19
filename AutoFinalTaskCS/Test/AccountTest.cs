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
        //private static AccountPage _accountPage = null!;
        //private static WishlistPage _wishlistPage = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        [Test]
        public void TestRegister()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Register();
            
            Assert.AreEqual("Sign out", _accountPage.GetSignOutButtonName(), "Login failed.");
        }

        [Test]
        public void TestLogin()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();
            
            Assert.AreEqual("Sign out", _accountPage.GetSignOutButtonName(), "Login failed.");
        }

        [Test]
        public void TestWishlistAutoCreation()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            WishlistPage _wishlistPage = new(Driver);
            _wishlistPage.GoToURL();
            if (_wishlistPage.CheckWishlistIsEmpty())
            {
                _wishlistPage.GoToItemURL();
                _wishlistPage.AddItemToWishlist();
                _wishlistPage.GoToURL();

                if (_wishlistPage.CheckItemIsAddedToWishlist())
                {
                    _wishlistPage.GoToItemURL();
                    _wishlistPage.AddItemToWishlist();
                    _wishlistPage.GoToURL();

                    Assert.IsTrue(_wishlistPage.CheckItemIsAddedToWishlist(), "Wishlist was not created automatically.");
                }
                else
                {
                    throw new Exception("Item was not added to the wishlist.");
                }
            }
            else
            {
                throw new Exception("Wishlist exists.");
            }            
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