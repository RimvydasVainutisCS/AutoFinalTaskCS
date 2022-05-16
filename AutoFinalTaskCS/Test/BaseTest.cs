using AutoFinalTaskCS.Drivers;
using AutoFinalTaskCS.Page;
using AutoFinalTaskCS.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Test
{
    public class BaseTest
    {
        private static IWebDriver Driver = null!;
        private static AccountPage LoginPage = null!;

        // public static ExamplePage examplePage;


        [OneTimeSetUp]
        public void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();
            LoginPage = new AccountPage(Driver);
            // Which implicit wait approach is better?
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotTool.MakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Driver.Quit();
        }
    }
}
