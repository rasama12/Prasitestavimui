using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Security.Principal;
using System.Xml.Linq;
using NUnit.Framework.Interfaces;
using System.IO;

namespace Prasitestavimui
{
    public class OtherCases
    {
        static IWebDriver driver;
        static GeneralMethods generalMethods;
        static LoginToPage loginToPage;
        static ProductList productList;
        static CheckPricesSorting checkPricesSorting;
        static CheckTitleIsCorrect checkTitleIsCorrect;



        [SetUp]
        public static void SETUP()
        {
            driver = GeneralMethods.CreateDriver();

            generalMethods = new GeneralMethods(driver);
            loginToPage = new LoginToPage(driver);
            productList = new ProductList(driver);
            checkPricesSorting = new CheckPricesSorting(driver);
            checkTitleIsCorrect = new CheckTitleIsCorrect(driver);

            driver.Manage().Window.Maximize();
            driver.Url = "https://fera.lt";
            generalMethods.WaitElement("//a[@data-cc-event='click:dismiss']", driver).Click();

        }
        [TearDown]
        public static void TearDown()
        {
            var countToLEave = 4;
            var failai = Directory.GetFiles("Screenshots").ToList();
            failai.Sort();
            if (failai.Count > countToLEave)
            {
                for (int i = 0; i < failai.Count - countToLEave; i++)
                {
                    File.Delete(failai[i]);
                }
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var name =
                    $"{TestContext.CurrentContext.Test.MethodName}" +
                    $" Error at " +
                    $"{DateTime.Now.ToString().Replace(":", "_")}";

                GeneralMethods.ScreenShot(driver, name);

                File.WriteAllText(
                    $"Screenshots\\{name}.txt",
                    TestContext.CurrentContext.Result.Message);
            }
            driver.Close();
            driver.Quit();
        }

        [Test]
        public static void Test1_CheckTitleIsCorrect()
        {
            string expectedTitle = "FERA.LT - Gyvūnų prekių parduotuvė";
            var actualTitle = checkTitleIsCorrect.CheckTitle();
            Assert.AreEqual(expectedTitle, actualTitle, "Wrong Title");
        }


        [Test]
        public static void Test2_LoginTest()
        {
            loginToPage.ClickLoginButton();
            loginToPage.EnterEmailAndPassword();
            loginToPage.PressLoginButton();

            generalMethods.Notification();

            Assert.AreEqual(loginToPage.GetUserNameText(), loginToPage.ActualMyAccountMailText, "Wrong");
        }


        [Test]
        public static void Test3_ProductList()
        {
            productList.FindFirstProduct();
            productList.AddToMyBasket();
            
            var count = productList.BasketCount();
            Assert.AreEqual(1, count);
           
            var prices = productList.BasketPrice();
            Assert.AreEqual(4.84, prices, 0.001);
        }

        [Test]
        public static void Test4_CheckPricesSorting()
        {
            checkPricesSorting.ChoosePrice();
            Assert.IsTrue(checkPricesSorting.SortPrices());
        }

    }
}






