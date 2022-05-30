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
        public static IWebDriver Driver = null!;
        public const AccountPage _accountPage = null!;
        public const WishlistPage _wishlistPage = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                Driver = CustomDriver.GetChromeDriver();
                //Driver = CustomDriver.GetFirefoxDriver();
                //Driver = CustomDriver.GetDockerRemote();
                //Driver = CustomDriver.GetSauceLabsChrome();
                //Driver = CustomDriver.GetSauceLabsFirefox();
                Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));

            }
            catch (Exception)
            {
                Console.WriteLine(Environment.StackTrace);
            }
        }

        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotTool.MakeScreenshot(Driver);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
