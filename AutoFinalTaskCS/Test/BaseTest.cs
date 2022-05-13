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
        private static IWebDriver driver = null!;
        private static AccountPage loginPage = null!;

        // public static ExamplePage examplePage;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // Which implicit wait approach is better?
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotTool.MakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
