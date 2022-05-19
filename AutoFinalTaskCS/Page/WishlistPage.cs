using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Page
{
    public class WishlistPage
    {
        const string URL = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        const string ITEM_URL = "http://automationpractice.com/index.php?id_product=7&controller=product";

        private static readonly By _wishlistBlock = By.CssSelector("#block-history");
        private static readonly By _wishlistButton = By.CssSelector("#wishlist_button");

        //private static readonly By _wishlistBlock = By.CssSelector("#block-history");

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
    }
}
