using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Prasitestavimui
{
    internal class GeneralMethods
    {
        IWebDriver driver;

        public GeneralMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static IWebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            return new ChromeDriver(options);
        }
        public IWebElement WaitElement(string xPath, IWebDriver driver)
        { 
            return WaitElement(By.XPath(xPath), driver);
        }

        public IWebElement WaitElement(By by, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromSeconds(0.5);
            return wait.Until(d => d.FindElement(by));
        }

        public static void ScreenShot(IWebDriver driver, string fileName)
        {
            var s = driver as ITakesScreenshot;
            var screenshot = s.GetScreenshot();
            if (!Directory.Exists("Screenshots"))
            {
                Directory.CreateDirectory("Screenshots");
            }
            screenshot.SaveAsFile($"Screenshots\\{fileName}.png",
                ScreenshotImageFormat.Png);

        
        }
        public void CheckElement(string xpath)
        {
             driver.FindElement(By.XPath(xpath));
        }
        public void HoverAndCLickBy(string xpath)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(xpath))).Perform();
            driver.FindElement(By.XPath(xpath)).Click();
        }

        public void Notification()
        {
            var notification = WaitElement(By.CssSelector("div.notification-container"), driver);
            while (notification.Size.Height > 0)
                Thread.Sleep(50);
        }
    }
 }
