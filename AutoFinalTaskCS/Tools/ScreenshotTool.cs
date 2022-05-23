using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace AutoFinalTaskCS.Tools
{
    public class ScreenshotTool
    {
        public static void MakeScreenshot(IWebDriver _driver)
        {
            Screenshot myBrowserScreenshot = _driver.TakeScreenshot();
            string? screenshotDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            string? screenshotFolder = Path.Combine(screenshotDirectory!, "screenshot");
            Directory.CreateDirectory(screenshotFolder);
            string? screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd}_{DateTime.Now:HHmmss}.png";
            string? screenshotPath = Path.Combine(screenshotFolder, screenshotName);
            myBrowserScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }
    }
}
