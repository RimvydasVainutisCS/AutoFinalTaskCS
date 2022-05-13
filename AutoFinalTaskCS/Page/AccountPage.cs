using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Page
{
    public class AccountPage : BasePage
    {
        private readonly string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string EMAIL_ADDRESS = "random@randomium.com";
        private readonly string FIRST_NAME = "Firstname";
        private readonly string LAST_NAME = "Lastname";
        private readonly string PWD = "Pa55word^D1ff1cult_3%14";
        private readonly string ADDRESS = "Street 123-4";
        private readonly string CITY = "City";
        private readonly string STATE = "Utah";
        private readonly string POSTAL_CODE = "84001";
        private readonly string MOBILE_PHONE = "+155569875669";
        private readonly string ADDRESS_ALIAS = "TrainingAddressAlias";

        // Main register/login page form
        private static readonly By CREATE_ACCOUNT_EMAIL_ADDRESS_INPUT = By.CssSelector("#email_create");
        private static readonly By CREATE_ACCOUNT_BUTTON = By.CssSelector("#SubmitCreate");
        
        // Customer form (mandatory input fields)
        private static readonly By FIRST_NAME_CUSTOMER_INPUT = By.CssSelector("#customer_firstname");
        private static readonly By LAST_NAME_CUSTOMER_INPUT = By.CssSelector("#customer_lastname");
        private static readonly By ACCOUNT_PASSWORD_INPUT = By.CssSelector("#passwd");

        // Address form (mandatory input fields)
        private static readonly By FIRST_NAME_ADDRESS_INPUT = By.XPath("//*[@id='firstname']");
        private static readonly By LAST_NAME_ADDRESS_INPUT = By.XPath("//*[@id='lastname']");
        private static readonly By ADDRESS_INPUT = By.CssSelector("#address1");
        private static readonly By CITY_INPUT = By.CssSelector("#city");

        // Trying to select Utah just by the option value //
        private static readonly By UTAH_STATE_OPTION = By.CssSelector("#id_state > option:nth-child(48)");

        private static readonly By MOBILE_PHONE_INPUT = By.CssSelector("#phone_mobile");
        private static readonly By ADDRESS_ALIAS_INPUT = By.CssSelector("#alias");

        public AccountPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public AccountPage Register()
        {
            IWebElement emailAddressCreateInput = Driver.FindElement(CREATE_ACCOUNT_EMAIL_ADDRESS_INPUT);
            emailAddressCreateInput.SendKeys(EMAIL_ADDRESS);
            IWebElement createAccountButton = Driver.FindElement(CREATE_ACCOUNT_BUTTON);
            createAccountButton.Click();



            return this;
        }
    }
}
