using OpenQA.Selenium;

namespace AutoFinalTaskCS.Page
{
    public class BasePage
    {
        protected IWebDriver Driver = null!;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}