using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prasitestavimui
{
    internal class ProductList
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        By CatName = By.XPath("(//li[@class='ty-menu__item cm-menu-item-responsive'])[2]");
        By CatName2 = By.XPath("(//div[@class='item1-wrapper']//a)[8]");
        By CatName3 = By.XPath("//img[@title='Kačių kraikas']");
        By FirstProduct = By.XPath("(//a[@class='product-title'])[1]");
        string FirstProductXPath = "(//a[@class='product-title'])[1]";
        By addToBasket = By.XPath("//a[@id='button_cart_44550']");
        By myBasket = By.XPath("//div[@class=' top-cart-content et-cart ty-float-right']");
        By lookMyBasket = By.XPath("//a[@class='ty-btn ty-btn__tertiary']");
        By newPicture = By.XPath("//div[@class='snrs-modal-btn-close']");
        By countInBasket = By.XPath("//div[@class='et-cart-content hidden-desktop']");
        By priceOfItem = By.XPath("//span[@id='sec_product_price_1266832332']");

        public ProductList(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public void FindFirstProduct()
        {
            driver.FindElement(CatName).Click();
            driver.FindElement(CatName2).Click();
            driver.FindElement(CatName3).Click();
            generalMethods.HoverAndCLickBy(FirstProductXPath);
        }
        public void AddToMyBasket()
        {
            driver.FindElement(addToBasket).Click();
            //thread.sleep reikalingas, nes kitaip nespeja preke atsidurti krepselyje, o jau prasideda krepselio tikrinimas
            Thread.Sleep(8000);
            driver.FindElement(myBasket).Click();
            driver.FindElement(lookMyBasket).Click();
        }
        public int BasketCount()
        {
            string count = driver.FindElement(countInBasket).Text;
            return int.Parse(count);
        }
        public double BasketPrice()
        {
            string itemPrice = driver.FindElement(priceOfItem).Text;
            return double.Parse(itemPrice.Replace(".", ","));
        }
    }
}
