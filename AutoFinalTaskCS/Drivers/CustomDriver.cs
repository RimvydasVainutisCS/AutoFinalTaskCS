using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

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
        public static IWebDriver GetDockerRemote()
        {
            return GetDriver(Browsers.DockerRemote);
        }
        public static IWebDriver GetSauceLabsChrome()
        {
            return GetDriver(Browsers.SauceLabsChromeOptions);
        }
        public static IWebDriver GetSauceLabsFirefox()
        {
            return GetDriver(Browsers.SauceLabsFirefoxOptions);
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

                case Browsers.DockerRemote:
                    ChromeOptions chromeOptions = new();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    break;

                case Browsers.SauceLabsChromeOptions:
                    var sauceLabsChromeOptions = new ChromeOptions
                    {
                        PlatformName = "macOS 12",
                        BrowserVersion = "latest"
                    };
                    var sauceChromeOptions = new Dictionary<string, object>();
                    sauceLabsChromeOptions.AddAdditionalOption("sauce:options", sauceChromeOptions);

                    driver = new RemoteWebDriver(
                        new Uri("https://oauth-rimvydasvainutis-0ec30:6e994015-8bb9-4e3f-b1c3-99e7630a0631@ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
                        sauceLabsChromeOptions.ToCapabilities(),
                        TimeSpan.FromSeconds(600));
                    break;

                case Browsers.SauceLabsFirefoxOptions:
                    var sauceLabsFirefoxOptions = new FirefoxOptions
                    {
                        PlatformName = "Windows 8.1",
                        BrowserVersion = "latest"
                    };
                    var sauceFirefoxOptions = new Dictionary<string, object>();
                    sauceLabsFirefoxOptions.AddAdditionalOption("sauce:options", sauceFirefoxOptions);

                    driver = new RemoteWebDriver(
                        new Uri("https://oauth-rimvydasvainutis-0ec30:6e994015-8bb9-4e3f-b1c3-99e7630a0631@ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
                        sauceLabsFirefoxOptions.ToCapabilities(),
                        TimeSpan.FromSeconds(600));
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
