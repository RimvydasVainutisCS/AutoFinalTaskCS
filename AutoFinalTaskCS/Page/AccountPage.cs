using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Page
{
    public class AccountPage : BasePage
    {
        const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        const string EMAIL_ADDRESS = "random3@randomium.com";
        const string FIRST_NAME = "Firstname";
        const string LAST_NAME = "Lastname";
        const string PASSWORD = "Pa55word^D1ff1cult_3%14";
        const string ADDRESS = "Street 123-4";
        const string CITY = "City";
        //private readonly string STATE = "Utah";
        const string POSTAL_CODE = "84001";
        const string MOBILE_PHONE = "+155569875669";
        const string ADDRESS_ALIAS = "TrainingAddressAlias";

        // Main register/login page form
        private static readonly By _createAccountEmailAddressInput = By.CssSelector("#email_create");
        private static readonly By _createAccountButton= By.CssSelector("#SubmitCreate");

        // Account creation form locator
        private static readonly By _accountCreationForm = By.CssSelector("#account-creation_form");

        // Customer form (mandatory input fields)
        private static readonly By _firstNameCustomerInput = By.CssSelector("#customer_firstname");
        private static readonly By _lastNameCustomerInput = By.CssSelector("#customer_lastname");
        private static readonly By _accountPasswordInput = By.CssSelector("#passwd");

        // Address form (mandatory input fields)
        // First name and Last name are filled automatically 
        //private static readonly By _firstNameAddressInput = By.XPath("//*[@id='firstname']");
        //private static readonly By _lastNameAddressInput = By.XPath("//*[@id='lastname']");
        private static readonly By _addressInput = By.CssSelector("#address1");
        private static readonly By _cityInput = By.CssSelector("#city");

        // Trying to select Utah just by the option value //
        private static readonly By _utahStateOption = By.CssSelector("#id_state > option:nth-child(48)");
        private static readonly By _postCodeInput = By.CssSelector("#postcode");

        private static readonly By _mobilePhoneInput = By.CssSelector("#phone_mobile");
        private static readonly By _addressAliasInput = By.CssSelector("#alias");

        private static readonly By _registerButton = By.CssSelector("#submitAccount");

        private new readonly IWebDriver driver = null!;

        public AccountPage(IWebDriver driver) : base(driver) { }

        public void GoToURL()
        {
            driver.Navigate().GoToUrl(URL);
        }

        public AccountPage Register()
        {
            IWebElement emailAddressInput = driver.FindElement(_createAccountEmailAddressInput);
            emailAddressInput.Clear();
            emailAddressInput.SendKeys(EMAIL_ADDRESS);
            IWebElement createAccountButton = driver.FindElement(_createAccountButton);
            createAccountButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = driver.FindElement(_accountCreationForm);
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


            IWebElement firstNameInput = driver.FindElement(_firstNameCustomerInput);
            firstNameInput.Clear();
            firstNameInput.SendKeys(FIRST_NAME);
            IWebElement lastNameInput = driver.FindElement(_lastNameCustomerInput);
            lastNameInput.Clear();
            lastNameInput.SendKeys(LAST_NAME);
            IWebElement passwordInput = driver.FindElement(_accountPasswordInput);
            passwordInput.Clear();
            passwordInput.SendKeys(PASSWORD);
            IWebElement addressInput = driver.FindElement(_addressInput);
            addressInput.Clear();
            addressInput.SendKeys(ADDRESS);
            IWebElement cityInput = driver.FindElement(_cityInput);
            cityInput.Clear();
            cityInput.SendKeys(CITY);
            // Possibly this won't work, webelement ACTION needed
            IWebElement stateSelect = driver.FindElement(_utahStateOption);
            stateSelect.Click();
            IWebElement zipCode = driver.FindElement(_postCodeInput);
            zipCode.Clear();
            zipCode.SendKeys(POSTAL_CODE);
            IWebElement mobilePhoneInput = driver.FindElement(_mobilePhoneInput);
            mobilePhoneInput.Clear();
            mobilePhoneInput.SendKeys(MOBILE_PHONE);
            IWebElement addressAliasInput = driver.FindElement(_addressAliasInput);
            addressAliasInput.Clear();
            addressAliasInput.SendKeys(ADDRESS_ALIAS);
            IWebElement registerButton = driver.FindElement(_registerButton);
            registerButton.Click();

            return new AccountPage(driver);
        }
    }
}
