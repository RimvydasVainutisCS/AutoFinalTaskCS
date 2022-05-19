using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutoFinalTaskCS.Page
{
    public class AccountPage
    {
        const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        const string EMAIL_ADDRESS = "random6@randomium.com";
        const string FIRST_NAME = "Firstname";
        const string LAST_NAME = "Lastname";
        const string PASSWORD = "Pa55word^D1ff1cult_3%14";
        const string ADDRESS = "Street 123-4";
        const string CITY = "City";
        const string POSTAL_CODE = "84001";
        const string MOBILE_PHONE = "+155569875669";
        const string ADDRESS_ALIAS = "TrainingAddressAlias";

        private static readonly By _createAccountEmailAddressInput = By.CssSelector("#email_create");
        private static readonly By _createAccountButton = By.CssSelector("#SubmitCreate");
        private static readonly By _accountCreationForm = By.CssSelector("#account-creation_form");
        private static readonly By _firstNameCustomerInput = By.CssSelector("#customer_firstname");
        private static readonly By _lastNameCustomerInput = By.CssSelector("#customer_lastname");
        private static readonly By _accountPasswordInput = By.CssSelector("#passwd");
        private static readonly By _addressInput = By.CssSelector("#address1");
        private static readonly By _cityInput = By.CssSelector("#city");
        private static readonly By _utahStateOption = By.CssSelector("#id_state > option:nth-child(48)");
        private static readonly By _postCodeInput = By.CssSelector("#postcode");
        private static readonly By _mobilePhoneInput = By.CssSelector("#phone_mobile");
        private static readonly By _addressAliasInput = By.CssSelector("#alias");
        private static readonly By _registerButton = By.CssSelector("#submitAccount");
        private static readonly By _loginForm = By.CssSelector("#login_form");
        private static readonly By _loginEmailInput = By.CssSelector("#email");
        private static readonly By _loginPasswordInput = By.CssSelector("#passwd");
        private static readonly By _loginSignInButton = By.CssSelector("#SubmitLogin");
        private static readonly By _signOutButton = By.CssSelector("a[class='logout']");

        private readonly IWebDriver Driver = null!;

        public AccountPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToURL()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public AccountPage Register()
        {
            IWebElement emailAddressInput = Driver.FindElement(_createAccountEmailAddressInput);
            emailAddressInput.Clear();
            emailAddressInput.SendKeys(EMAIL_ADDRESS);
            IWebElement createAccountButton = Driver.FindElement(_createAccountButton);
            createAccountButton.Click();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_accountCreationForm);
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

            IWebElement firstNameInput = Driver.FindElement(_firstNameCustomerInput);
            firstNameInput.Clear();
            firstNameInput.SendKeys(FIRST_NAME);
            IWebElement lastNameInput = Driver.FindElement(_lastNameCustomerInput);
            lastNameInput.Clear();
            lastNameInput.SendKeys(LAST_NAME);
            IWebElement passwordInput = Driver.FindElement(_accountPasswordInput);
            passwordInput.Clear();
            passwordInput.SendKeys(PASSWORD);
            IWebElement addressInput = Driver.FindElement(_addressInput);
            addressInput.Clear();
            addressInput.SendKeys(ADDRESS);
            IWebElement cityInput = Driver.FindElement(_cityInput);
            cityInput.Clear();
            cityInput.SendKeys(CITY);
            IWebElement stateSelect = Driver.FindElement(_utahStateOption);
            stateSelect.Click();
            IWebElement zipCode = Driver.FindElement(_postCodeInput);
            zipCode.Clear();
            zipCode.SendKeys(POSTAL_CODE);
            IWebElement mobilePhoneInput = Driver.FindElement(_mobilePhoneInput);
            mobilePhoneInput.Clear();
            mobilePhoneInput.SendKeys(MOBILE_PHONE);
            IWebElement addressAliasInput = Driver.FindElement(_addressAliasInput);
            addressAliasInput.Clear();
            addressAliasInput.SendKeys(ADDRESS_ALIAS);
            IWebElement registerButton = Driver.FindElement(_registerButton);
            registerButton.Click();

            return new AccountPage(Driver);
        }

        public AccountPage Login()
        {
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            bool element = wait.Until(condition =>
            {
                try
                {
                    IWebElement elementToBeDisplayed = Driver.FindElement(_loginForm);
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

            IWebElement loginEmailInput = Driver.FindElement(_loginEmailInput);
            loginEmailInput.Clear();
            loginEmailInput.SendKeys(EMAIL_ADDRESS);
            IWebElement loginPasswordInput = Driver.FindElement(_loginPasswordInput);
            loginPasswordInput.Clear();
            loginPasswordInput.SendKeys(PASSWORD);
            IWebElement loginSignInButton = Driver.FindElement(_loginSignInButton);
            loginSignInButton.Click();

            return new AccountPage(Driver);
        }

        public string GetSignOutButtonName()
        {
            IWebElement signOutButton = Driver.FindElement(_signOutButton);
            string result = signOutButton.Text.ToString();

            return result;
        }
    }
}
