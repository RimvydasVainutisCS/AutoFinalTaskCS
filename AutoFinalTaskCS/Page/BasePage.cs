using OpenQA.Selenium;

namespace AutoFinalTaskCS.Page
{
    public class BasePage
    {
        protected readonly IWebDriver Driver = null!;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
