using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverAdv.PO
{
    class AllProductsPage
    {
        private IWebDriver driver;
        private IWebElement createProductBtn => driver.FindElement(By.XPath("//div/a[text()=\"Create new\"]"));
        private IWebElement logoutBtn => driver.FindElement(By.XPath("//a[text()=\"Logout\"]"));
        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public ProductPage CreateProduct()
        {
            createProductBtn.Click();
            return new ProductPage(driver);
        }
        public ProductPage OpenProduct(string name)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{name}\"]")).Click();
            return new ProductPage(driver);
        }

        public void DeleteProduct(string name)
        {
            driver.FindElement(By.XPath($"//a[text()=\"{name}\"]/..//following-sibling::*/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
        }
        public void WaitLoading(IWebDriver driver, string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//table//a[text()=\"{name}\"]")));
        }
        public bool isElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool IsProductPresent(string name)
        {
            return isElementPresent(By.XPath($"//table//a[text()=\"{name}\"]"));
        }
        public LoginPage Logout()
        {
            logoutBtn.Click();
            return new LoginPage(driver);
        }

    }
}
