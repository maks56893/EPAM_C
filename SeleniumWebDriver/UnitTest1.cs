using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumWebDriver
{
    public class Tests
    {

        private IWebDriver driver;
        private WebDriverWait wait;

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

        [OneTimeSetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        [Test, Order(1)]
        public void Login()
        {

            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            string logintext = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("Home page", logintext);            
        }

        [Test, Order(2)]
        public void Add()
        {
            driver.FindElement(By.XPath("//div/div/a[text()=\"All Products\"]")).Click();
            driver.FindElement(By.XPath("//div/a[text()=\"Create new\"]")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("eda");
            IWebElement selectElemCat = driver.FindElement(By.Id("CategoryId"));
            SelectElement selectCat = new SelectElement(selectElemCat);
            selectCat.SelectByValue("1");
            IWebElement selectElemSup = driver.FindElement(By.Id("SupplierId"));
            SelectElement selectSup = new SelectElement(selectElemSup);
            selectSup.SelectByValue("21");
            driver.FindElement(By.Id("UnitPrice")).SendKeys("12");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("1");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("111");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("2");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("1");
            driver.FindElement(By.CssSelector(".btn")).Click();
            string ProductsText = driver.FindElement(By.XPath("//h2")).Text;
            Assert.AreEqual("All Products", ProductsText);
            Assert.IsTrue(isElementPresent(By.XPath("//*[@class='table']//a[text()='eda']")));
        }

        [Test, Order(3)]
        public void CheckProduct()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'eda')]")).Click();
            string ProductName = driver.FindElement(By.XPath("//input[@name=\"ProductName\"]")).GetAttribute("value");
            string UnitPrice = driver.FindElement(By.XPath("//input[@id=\"UnitPrice\"]")).GetAttribute("value");
            string QuantityPerUnit = driver.FindElement(By.XPath("//input[@id=\"QuantityPerUnit\"]")).GetAttribute("value");
            string UnitsInStock = driver.FindElement(By.XPath("//input[@id=\"UnitsInStock\"]")).GetAttribute("value");
            string UnitsOnOrder = driver.FindElement(By.XPath("//input[@id=\"UnitsOnOrder\"]")).GetAttribute("value");
            string ReorderLevel = driver.FindElement(By.XPath("//input[@id=\"ReorderLevel\"]")).GetAttribute("value");
            IWebElement selectElemCat = driver.FindElement(By.Id("CategoryId"));
            SelectElement selectCat = new SelectElement(selectElemCat);
            string CategoryId = selectCat.SelectedOption.Text;
            IWebElement selectElemSup = driver.FindElement(By.Id("SupplierId"));
            SelectElement selectElemCup = new SelectElement(selectElemSup);
            string SupplierId = selectElemCup.SelectedOption.Text;
            Assert.AreEqual(ProductName, "eda");
            Assert.AreEqual(CategoryId, "Beverages");
            Assert.AreEqual(SupplierId, "Lyngbysild");            
            Assert.AreEqual(UnitPrice, "12,0000");
            Assert.AreEqual(QuantityPerUnit, "1");
            Assert.AreEqual(UnitsInStock, "111");
            Assert.AreEqual(UnitsOnOrder, "2");
            Assert.AreEqual(ReorderLevel, "1");
            driver.FindElement(By.XPath("//a[text()=\"All Products\"]")).Click();
        }

        [Test, Order(4)]
        public void Delete()
        {
            driver.FindElement(By.XPath("//a[text()=\"eda\"]/..//following-sibling::*/a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//table//a[text()=\"eda\"]")));
            Assert.IsFalse(isElementPresent(By.XPath("//table//a[text()=\"eda\"]")));
        }

        [Test, Order(5)]
        public void Logout()
        {
            driver.FindElement(By.XPath("//a[text()=\"Logout\"]")).Click();
            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Login");
        }


        [OneTimeTearDown]
        public void QuitDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}