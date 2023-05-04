using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Prasitestavimui
{
    internal class LoginToPage
    {
        IWebDriver driver;
        GeneralMethods generalMethods;

        string[] userData;
        By myAccount = By.XPath("//div[contains(@class,'my-account-text')]");
        By login = By.XPath("//a[@class='cm-dialog-opener cm-dialog-auto-size account']");

        By emailInput = By.Id("login_popup423");
        By passwordInput = By.Id("psw_popup423");
        By loginButton = By.XPath("//button[@name='dispatch[auth.login]']");

        public LoginToPage(IWebDriver driver)
        {
            this.driver = driver;
            generalMethods = new GeneralMethods(driver);
            userData = System.IO.File.ReadAllLines(@"C:\Users\Rasa\Desktop\paskaitos\Prasitestavimui\Prasitestavimui\Prisijungimas.txt");
        }
        public void ClickLoginButton()
        {
            driver.FindElement(myAccount).Click();
            driver.FindElement(login).Click();
        }
       
        public void EnterEmailAndPassword()
        {
            driver.FindElement(emailInput).SendKeys(userData[0]);
            driver.FindElement(passwordInput).SendKeys(userData[1]);
        }
        public void PressLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }
        public string GetUserNameText()
        {
            generalMethods.WaitElement(myAccount, driver).Click();
            By myAccountMail = By.XPath("//li[contains(@class,'account-info__name')]");
            string myAccountMailText = driver.FindElement(myAccountMail).Text;
            return myAccountMailText;
        }

        public string ActualMyAccountMailText => userData[0];
    }
}

