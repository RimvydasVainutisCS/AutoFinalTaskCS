using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutoFinalTaskCS.Page
{
    public class WishlistPage
    {
        const string URL = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        const string ITEM_URL = "http://automationpractice.com/index.php?id_product=7&controller=product";
        const string ITEM_NAME = "Printed Chiffon Dress\r\nS, Yellow";
        const string CUSTOM_WISHLIST_NAME = "Custom Wishlist";

        private static readonly By _wishlistBlock = By.CssSelector("#block-history");
        private static readonly By _wishlistButton = By.CssSelector("#wishlist_button");
        private static readonly By _newWishlistNameField = By.CssSelector("#name");
        private static readonly By _newWishlistSaveButton = By.CssSelector("#submitWishlist");
        private static readonly By _customWishlistLink = By.XPath(".//td[1]/a");
        private static readonly By _customWishlistItemName = By.CssSelector("p[class='product-name']");
        private static readonly By _deleteWishlistButton = By.XPath(".//td[6]/a");

        private readonly IWebDriver Driver = null!;
        public WishlistPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void GoToURL()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public bool CheckWishlistIsEmpty()
        {
            IReadOnlyCollection<IWebElement> wishlist = Driver.FindElements(_wishlistBlock);
            if (wishlist.Count == 0)
            {
                return true;
            }
            else
            {
                throw new Exception("Wishlist already exist.");
            }
        }

        public void GoToItemURL()
        {
            Driver.Navigate().GoToUrl(ITEM_URL);
        }

        public void AddItemToWishlist()
        {
            IWebElement wishlistButton = Driver.FindElement(_wishlistButton);
            wishlistButton.Click();
        }

        public bool CheckItemIsAddedToWishlist()
        {
            IWebElement wishlistBlockItems = Driver.FindElement(_wishlistBlock);
            if (wishlistBlockItems.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateCustomWishlist()
        {
            IWebElement wishlistNameField = Driver.FindElement(_newWishlistNameField);
            wishlistNameField.SendKeys(CUSTOM_WISHLIST_NAME);
            IWebElement newWishlistSaveButton = Driver.FindElement(_newWishlistSaveButton);
            newWishlistSaveButton.Click();
        }

        public bool CheckItemAddedToCustomWishlist()
        {
            IWebElement customWishlistLink = Driver.FindElement(_customWishlistLink);
            customWishlistLink.Click();
            Thread.Sleep(6000);

            IWebElement customWishlistItemName = Driver.FindElement(_customWishlistItemName);
            if (customWishlistItemName.Text == ITEM_NAME)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteWishlist()
        {
            IWebElement deleteWishlistButton = Driver.FindElement(_deleteWishlistButton);
            deleteWishlistButton.Click();
        }
    }
}
