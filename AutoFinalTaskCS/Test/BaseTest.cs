using AutoFinalTaskCS.Drivers;
using AutoFinalTaskCS.Page;
using AutoFinalTaskCS.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
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
        private static ExamplePage examplePage;

        // public static ExamplePage examplePage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
            examplePage = new ExamplePage(Driver);
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
