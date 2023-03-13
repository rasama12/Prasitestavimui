using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V108.CSS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Security.Principal;
using System.Xml.Linq;

namespace Prasitestavimui
{
    public class OtherCases
    {
        static IWebDriver driver;
        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://pigu.lt/lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            By CookieAgreeButton = By.XPath("//button[@class='c-btn--primary h-btn--small']");
            driver.FindElement(CookieAgreeButton).Click();


        }
        [TearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
        [Test]
        public static void Navigation()
        {
            //IWebElement el = driver.FindElement(By.XPath(""));
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.Exec

            By searchField = By.XPath("//input[@id='searchInput']");
            driver.FindElement(searchField).SendKeys("skalbimo mašinos");
            By clicSearchButton = By.XPath("//i[@class='c-icon--search']");
            driver.FindElement(clicSearchButton).Click();
            By firstProduct = By.XPath("//img[@title='Beko WUE6512BA']");
            driver.FindElement(firstProduct).Click();   

        }
//testas
    }
        
        }
    

