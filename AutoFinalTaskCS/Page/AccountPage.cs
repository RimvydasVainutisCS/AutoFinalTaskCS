using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Page
{
    public class AccountPage// : BasePage
    {
        private readonly string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string EMAIL_ADDRESS = "random2@randomium.com";
        private readonly string FIRST_NAME = "Firstname";
        private readonly string LAST_NAME = "Lastname";
        private readonly string PASSWORD = "Pa55word^D1ff1cult_3%14";
        private readonly string ADDRESS = "Street 123-4";
        private readonly string CITY = "City";
        //private readonly string STATE = "Utah";
        private readonly string POSTAL_CODE = "84001";
        private readonly string MOBILE_PHONE = "+155569875669";
        private readonly string ADDRESS_ALIAS = "TrainingAddressAlias";

        // Main register/login page form
        private static readonly By CREATE_ACCOUNT_EMAIL_ADDRESS_INPUT = By.CssSelector("#email_create");
        private static readonly By CREATE_ACCOUNT_BUTTON = By.CssSelector("#SubmitCreate");

        // Account creation form locator
        private static readonly By ACCOUNT_CREATION_FORM = By.CssSelector("#account-creation_form");

        // Customer form (mandatory input fields)
        private static readonly By FIRST_NAME_CUSTOMER_INPUT = By.CssSelector("#customer_firstname");
        private static readonly By LAST_NAME_CUSTOMER_INPUT = By.CssSelector("#customer_lastname");
        private static readonly By ACCOUNT_PASSWORD_INPUT = By.CssSelector("#passwd");

        // Address form (mandatory input fields)
        // First name and Last name are filled automatically 
        //private static readonly By FIRST_NAME_ADDRESS_INPUT = By.XPath("//*[@id='firstname']");
        //private static readonly By LAST_NAME_ADDRESS_INPUT = By.XPath("//*[@id='lastname']");
        private static readonly By ADDRESS_INPUT = By.CssSelector("#address1");
        private static readonly By CITY_INPUT = By.CssSelector("#city");

        // Trying to select Utah just by the option value //
        private static readonly By UTAH_STATE_OPTION = By.CssSelector("#id_state > option:nth-child(48)");
        private static readonly By POST_CODE_INPUT = By.CssSelector("#postcode");

        private static readonly By MOBILE_PHONE_INPUT = By.CssSelector("#phone_mobile");
        private static readonly By ADDRESS_ALIAS_INPUT = By.CssSelector("#alias");

        private static readonly By REGISTER_BUTTON = By.CssSelector("#submitAccount");

        private readonly IWebDriver Driver;

        public AccountPage(IWebDriver Driver) // : base(webDriver)
        {
            this.Driver = Driver;
            this.Driver.Navigate().GoToUrl(URL);
        }

        public AccountPage Register()
        {
            IWebElement emailAddressInput = Driver.FindElement(CREATE_ACCOUNT_EMAIL_ADDRESS_INPUT);
            emailAddressInput.Clear();
            emailAddressInput.SendKeys(EMAIL_ADDRESS);
            IWebElement createAccountButton = Driver.FindElement(CREATE_ACCOUNT_BUTTON);
            createAccountButton.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(ACCOUNT_CREATION_FORM);
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


            IWebElement firstNameInput = Driver.FindElement(FIRST_NAME_CUSTOMER_INPUT);
            firstNameInput.Clear();
            firstNameInput.SendKeys(FIRST_NAME);
            IWebElement lastNameInput = Driver.FindElement(LAST_NAME_CUSTOMER_INPUT);
            lastNameInput.Clear();
            lastNameInput.SendKeys(LAST_NAME);
            IWebElement passwordInput = Driver.FindElement(ACCOUNT_PASSWORD_INPUT);
            passwordInput.Clear();
            passwordInput.SendKeys(PASSWORD);
            IWebElement addressInput = Driver.FindElement(ADDRESS_INPUT);
            addressInput.Clear();
            addressInput.SendKeys(ADDRESS);
            IWebElement cityInput = Driver.FindElement(CITY_INPUT);
            cityInput.Clear();
            cityInput.SendKeys(CITY);
            // Possibly this won't work, webelement ACTION needed
            IWebElement stateSelect = Driver.FindElement(UTAH_STATE_OPTION);
            stateSelect.Click();
            IWebElement zipCode = Driver.FindElement(POST_CODE_INPUT);
            zipCode.Clear();
            zipCode.SendKeys(POSTAL_CODE);
            IWebElement mobilePhoneInput = Driver.FindElement(MOBILE_PHONE_INPUT);
            mobilePhoneInput.Clear();
            mobilePhoneInput.SendKeys(MOBILE_PHONE);
            IWebElement addressAliasInput = Driver.FindElement(ADDRESS_ALIAS_INPUT);
            addressAliasInput.Clear();
            addressAliasInput.SendKeys(ADDRESS_ALIAS);
            IWebElement registerButton = Driver.FindElement(REGISTER_BUTTON);
            registerButton.Click();

            return new AccountPage(Driver);
        }
    }
}
