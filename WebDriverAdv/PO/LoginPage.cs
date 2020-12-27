using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverAdv.PO
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement LogInput => driver.FindElement(By.Id("Name"));
        private IWebElement PassInput => driver.FindElement(By.Id("Password"));
        private IWebElement LogBtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement Title => driver.FindElement(By.XPath("//h2"));

        public HomePage Login(string log, string pass)
        {
            new Actions(driver).SendKeys(LogInput, log).Build().Perform();
            new Actions(driver).SendKeys(PassInput, pass).Build().Perform();
            new Actions(driver).MoveToElement(LogBtn).Click(LogBtn).Build().Perform();
            return new HomePage(driver);
        }

        public string TitleText()
        {
            return driver.FindElement(By.XPath("//h2")).Text;
        }


    }
}
