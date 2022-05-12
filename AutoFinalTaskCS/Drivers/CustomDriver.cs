using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace AutoFinalTaskCS.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }
        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }
        public static IWebDriver GetEdgeDriver()
        {
            return GetDriver(Browsers.Edge);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver? driver = null!;

            switch (browserName)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver();
                    break;

                case Browsers.Firefox:
                    driver = new FirefoxDriver();
                    break;

                case Browsers.Edge:
                    driver = new EdgeDriver();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
