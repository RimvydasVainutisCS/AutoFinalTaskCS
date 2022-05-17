//using AutoFinalTaskCS.Drivers;
//using AutoFinalTaskCS.Page;
//using AutoFinalTaskCS.Tools;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Remote;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AutoFinalTaskCS.Test
//{
//    public class BaseTest
//    {
//        protected IWebDriver? Driver { get; private set; }
//        public static AccountPage _accountPage = null!;

//        [OneTimeSetUp]
//        public void Setup()
//        {
//            Driver = CustomDriver.GetChromeDriver();
//            //_accountPage = new AccountPage(driver);
//            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
//        }

//        [TearDown]
//        public void TakeScreenshot()
//        {
//            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
//            {
//                ScreenshotTool.MakeScreenshot(Driver);
//            }
//        }

//        [OneTimeTearDown]
//        public void TearDown()
//        {
//            Driver.Quit();
//        }
//    }
//}
