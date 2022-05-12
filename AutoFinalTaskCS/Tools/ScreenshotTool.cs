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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string screenshotDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            string screenshotFolder = Path.Combine(screenshotDirectory, "screenshot");
#pragma warning restore CS8604 // Possible null reference argument.
            Directory.CreateDirectory(screenshotFolder);
            string screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH_mm_ss}.png";
            string screenshotPath = Path.Combine(screenshotFolder, screenshotName);
            myBrowserScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }
    }
}
