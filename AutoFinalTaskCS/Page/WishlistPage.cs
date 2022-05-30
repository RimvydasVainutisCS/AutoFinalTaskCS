using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutoFinalTaskCS.Page
{
    public class WishlistPage : BasePage
    {
        const string URL = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        const string ITEM_ONE_URL = "http://automationpractice.com/index.php?id_product=7&controller=product";
        const string ITEM_ONE_NAME = "Printed Chiffon Dress\r\nS, Yellow";
        const string CUSTOM_WISHLIST_NAME = "Custom Wishlist";

        private static readonly By _newWishlistTable = By.CssSelector("#form_wishlist");
        private static readonly By _wishlistBlock = By.CssSelector("#block-history");
        private static readonly By _wishlistButton = By.CssSelector("#wishlist_button");
        private static readonly By _newWishlistNameField = By.CssSelector("#name");
        private static readonly By _newWishlistSaveButton = By.CssSelector("#submitWishlist");
        private static readonly By _customWishlistLink = By.XPath(".//td[1]/a");
        private static readonly By _customWishlistItemName = By.CssSelector("p[class='product-name']");
        private static readonly By _deleteWishlistButton = By.XPath(".//td[6]/a");
        private static readonly By _addedToWishlistCloseButton = By.XPath("//*[@id='product']/div[2]/div/div/a");


        public WishlistPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToURL()
        {
            Driver.Navigate().GoToUrl(URL);

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_newWishlistTable);
                    return elementToBeDisplayed.Displayed;
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
            Driver.Navigate().GoToUrl(ITEM_ONE_URL);

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_wishlistButton);
                    return elementToBeDisplayed.Displayed;
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
        }

        public void AddItemToWishlist()
        {
            IWebElement wishlistButton = Driver.FindElement(_wishlistButton);
            wishlistButton.Click();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_addedToWishlistCloseButton);
                    return elementToBeDisplayed.Displayed;
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

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_wishlistBlock);
                    return elementToBeDisplayed.Displayed;
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
        }

        public bool CheckItemAddedToCustomWishlist()
        {
            IWebElement customWishlistLink = Driver.FindElement(_customWishlistLink);
            customWishlistLink.Click();
            Thread.Sleep(6000);

            IWebElement customWishlistItemName = Driver.FindElement(_customWishlistItemName);

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_customWishlistItemName);
                    return elementToBeDisplayed.Displayed;
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

            if (customWishlistItemName.Text == ITEM_ONE_NAME)
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
            Driver.SwitchTo().Alert().Accept();
        }
    }
}
