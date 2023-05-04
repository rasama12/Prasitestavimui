using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prasitestavimui
{
    internal class CheckPricesSorting
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        By sortEl = By.XPath("(//div[@class='ty-sort-dropdown'])[1]");
        By lowestPrices = By.XPath("//li[@class='sort-by-price-asc ty-sort-dropdown__content-item']");
        By pricesBy = By.XPath("//span[@class='ty-price']");

        public CheckPricesSorting(IWebDriver driver)
        {

            this.driver = driver;
            generalMethods = new GeneralMethods(driver);

        }

        public void ChoosePrice()
        {
            driver.Url = "https://fera.lt/kaciu-kraikas/";
            generalMethods.WaitElement(sortEl, driver).Click();
            generalMethods.WaitElement(lowestPrices, driver).Click();

        }
        public bool SortPrices()
        {
            // čia Thread sleep'as nes puslapis keistai padarytas
            // Java Scriptas
            Thread.Sleep(3000);
            List<double> prices = new List<double>();


            foreach (IWebElement el in driver.FindElements(pricesBy))
            {
                string onePrice = el.Text;
                double onePriceDouble = double.Parse(onePrice.TrimStart("€".ToCharArray()).Replace(".", ","));
                prices.Add(onePriceDouble);
            }
            for (int i = 0; i < prices.Count - 1; i++)
            {
                Console.WriteLine(prices[i]);
                if (prices[i] > prices[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
    