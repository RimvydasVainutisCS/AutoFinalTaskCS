using OpenQA.Selenium;

namespace AutoFinalTaskCS.Page
{
    public class BasePage
    {
        protected readonly IWebDriver driver = null!;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
