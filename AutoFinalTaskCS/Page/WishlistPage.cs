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

        public void AddItemToWishlist()
        {
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement wishlistBlock = Driver.FindElement(_wishlistBlock);
                    return wishlistBlock.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            if (element == false)
            {
                Driver.Navigate().GoToUrl(ITEM_URL);
            }

            IWebElement wishlistButton = Driver.FindElement(_wishlistButton);
            wishlistButton.Click();
        }
    }
}
