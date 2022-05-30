using AutoFinalTaskCS.Page;
using NUnit.Framework;

namespace AutoFinalTaskCS.Test
{
    public class AccountTest : BaseTest
    {
        [Test, Order(1)]
        public void TestRegister()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Register();

            Assert.AreEqual("Sign out", _accountPage.GetSignOutButtonName(), "Login failed.");
        }

        [Test, Order(2)]
        public void TestLogin()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            Assert.AreEqual("Sign out", _accountPage.GetSignOutButtonName(), "Login failed.");
        }

        [Test, Order(3)]
        public void TestWishlistAutoCreation()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            WishlistPage _wishlistPage = new(Driver);
            _wishlistPage.GoToItemURL();
            _wishlistPage.CheckWishlistIsEmpty();
            _wishlistPage.AddItemToWishlist();
            _wishlistPage.GoToURL();
            _wishlistPage.CheckItemIsAddedToWishlist();

            Assert.IsTrue(_wishlistPage.CheckItemIsAddedToWishlist(), "Wishlist was not created automatically.");

            _wishlistPage.DeleteWishlist();
        }

        [Test, Order(4)]
        public void TestAddToCustomWishlist()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            WishlistPage _wishlistPage = new(Driver);
            _wishlistPage.GoToURL();
            _wishlistPage.CheckWishlistIsEmpty();
            _wishlistPage.CreateCustomWishlist();
            _wishlistPage.GoToItemURL();
            _wishlistPage.AddItemToWishlist();
            _wishlistPage.GoToURL();
            _wishlistPage.CheckItemAddedToCustomWishlist();

            Assert.IsTrue(_wishlistPage.CheckItemAddedToCustomWishlist(), "Wishlist was not created automatically.");

            _wishlistPage.DeleteWishlist();
        }

        [Test, Order(5)]
        public void TestAddThreeItemsToCart()
        {
            AccountPage _accountPage = new(Driver);
            _accountPage.GoToURL();
            _accountPage.Login();

            CartPage _cartPage = new(Driver);
            _cartPage.AddItemOneToCart();
            _cartPage.AddItemTwoToCart();
            _cartPage.AddItemThreeToCart();

            Assert.IsTrue(_cartPage.CheckCartItemsAdded(), "Items were not added to the Cart.");
            Assert.IsTrue(_cartPage.CheckCartTotalCorrect(), "Total sum of Cart is not correct.");

            _cartPage.CheckCartItemsAdded();
            _cartPage.CheckCartTotalCorrect();
        }
    }
}