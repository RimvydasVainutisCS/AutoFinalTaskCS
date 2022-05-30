using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Page
{
    public class CartPage : BasePage
    {
        const string URL = "http://automationpractice.com/index.php?controller=order";
        const string ITEM_ONE_URL = "http://automationpractice.com/index.php?id_product=7&controller=product";
        //const string ITEM_ONE_NAME = "Printed Chiffon Dress\r\nS, Yellow";
        //const string ITEM_ONE_PRICE = "$16.40";
        const string ITEM_TWO_URL = "http://automationpractice.com/index.php?id_product=3&controller=product";
        //const string ITEM_TWO_NAME = "Printed Dress";
        //const string ITEM_TWO_PRICE = "$26.00";
        const string ITEM_THREE_URL = "http://automationpractice.com/index.php?id_product=2&controller=product";
        //const string ITEM_THREE_NAME = "Blouse";
        //const string ITEM_THREE_PRICE = "$27.00";

        const string CART_THREE_ITEMS = "3 Products";
        const string CART_TOTAL_PRICE = "$71.40";

        private static readonly By _addToCartButton = By.XPath("//*[@id='add_to_cart']/button");
        private static readonly By _summaryProductsQuantity = By.CssSelector("#summary_products_quantity");
        private static readonly By _summaryProductsTotalPrice = By.CssSelector("#total_price");

        //private readonly IWebDriver Driver = null!;

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        //public CartPage(IWebDriver driver)
        //{
        //    Driver = driver;
        //}
        public void GoToURL()
        {
            Driver.Navigate().GoToUrl(URL);
        }
        public void AddItemOneToCart()
        {
            Driver.Navigate().GoToUrl(ITEM_ONE_URL);
            IWebElement addToCartButton = Driver.FindElement(_addToCartButton);
            addToCartButton.Click();
            Thread.Sleep(2000);
        }
        public void AddItemTwoToCart()
        {
            Driver.Navigate().GoToUrl(ITEM_TWO_URL);
            IWebElement addToCartButton = Driver.FindElement(_addToCartButton);
            addToCartButton.Click();
            Thread.Sleep(2000);
        }
        public void AddItemThreeToCart()
        {
            Driver.Navigate().GoToUrl(ITEM_THREE_URL);
            IWebElement addToCartButton = Driver.FindElement(_addToCartButton);
            addToCartButton.Click();
            Thread.Sleep(2000);
        }

        public bool CheckCartItemsAdded()
        {
            Driver.Navigate().GoToUrl(URL);
            IWebElement summaryProductsQuantity = Driver.FindElement(_summaryProductsQuantity);

            if (summaryProductsQuantity.Text == CART_THREE_ITEMS)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Items were not added to the Cart.");
            }
        }

        public bool CheckCartTotalCorrect()
        {
            IWebElement summaryProductsQuantity = Driver.FindElement(_summaryProductsTotalPrice);

            if (summaryProductsQuantity.Text == CART_TOTAL_PRICE)
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("Total price of the Cart is incorrect.");
            }
        }
    }
}
