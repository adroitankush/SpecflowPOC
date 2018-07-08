using System;
using System.IO;
using OpenQA.Selenium;

namespace Aviva
{
    class ScreenCapture
    {
        public String TakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string ScreenshotFile = "ErrorShot" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";
            string filepath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            filepath = Directory.GetParent(Directory.GetParent(filepath).FullName).FullName + "/Screenshots/" + ScreenshotFile;
            screenshot.SaveAsFile(filepath,
            ScreenshotImageFormat.Png);
            return filepath;
        }
    }
}
