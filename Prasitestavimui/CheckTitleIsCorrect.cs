using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prasitestavimui
{
    internal class CheckTitleIsCorrect
    {
        IWebDriver driver;
        GeneralMethods generalMethods;



        public CheckTitleIsCorrect(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
        }

        public string CheckTitle()
        {
           return driver.Title;
           

        }
    }    
}
