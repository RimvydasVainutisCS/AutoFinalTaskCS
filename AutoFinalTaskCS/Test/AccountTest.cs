using AutoFinalTaskCS.Tools;
using AutoFinalTaskCS.Drivers;
using AutoFinalTaskCS.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace AutoFinalTaskCS.Test
{
    public class AccountTest// : BaseTest
    {
        private static IWebDriver Driver = null!;
        private static AccountPage accountPage = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        [Test]
        public void TestRegister()
        {
            accountPage = new AccountPage(Driver);
            accountPage.GoToURL();
            accountPage.Register();
            IWebElement signOutLink = Driver.FindElement(By.CssSelector("a[class='logout']"));
            var result = signOutLink.Text.ToString();
            
            Assert.AreEqual("Sign out", result, "Login failed.");
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