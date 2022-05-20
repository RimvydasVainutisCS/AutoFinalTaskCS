using AutoFinalTaskCS.Drivers;
using AutoFinalTaskCS.Page;
using AutoFinalTaskCS.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutoFinalTaskCS.Test
{
    public class AccountTest
    {
        private static IWebDriver Driver = null!;

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
                    Assert.IsTrue(_wishlistPage.CheckItemIsAddedToWishlist(), "Wishlist was not created automatically.");
                }
                else
                {
                    throw new Exception("Item was not added to the wishlist.");
                }

                _wishlistPage.DeleteWishlist();
                Thread.Sleep(6000);
                Driver.SwitchTo().Alert().Accept();
                Thread.Sleep(8000);
            }
            else
            {
                throw new Exception("Wishlist exists.");
            }
        }

        [Test]
        public void TestAddToCustomWishlist()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            WishlistPage _wishlistPage = new(Driver);
            _wishlistPage.GoToURL();
            if (_wishlistPage.CheckWishlistIsEmpty())
            {
                _wishlistPage.CreateCustomWishlist();
                Thread.Sleep(3000);

                _wishlistPage.GoToItemURL();
                _wishlistPage.AddItemToWishlist();
                _wishlistPage.GoToURL();

                if (_wishlistPage.CheckItemAddedToCustomWishlist())
                {
                    Assert.IsTrue(_wishlistPage.CheckItemAddedToCustomWishlist(), "Wishlist was not created automatically.");
                }
                else
                {
                    throw new Exception("Item was not added to the wishlist.");
                }

                _wishlistPage.DeleteWishlist();
                Thread.Sleep(6000);
                Driver.SwitchTo().Alert().Accept();
                Thread.Sleep(8000);
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