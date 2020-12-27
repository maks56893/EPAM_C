using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverAdv.PO;

namespace WebDriverAdv
{
    public class Tests
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        private LoginPage loginPage;
        private HomePage homePage;
        private AllProductsPage allProductsPage;
        private ProductPage productPage;

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

            loginPage = new LoginPage(driver);
            homePage = loginPage.Login("user", "user");
            string logintext = homePage.TitleText();
            Assert.AreEqual("Home page", logintext);
        }

        [Test, Order(2)]
        public void Add()
        {
            homePage = new HomePage(driver);
            allProductsPage = homePage.ClickOnLink("All Products");
            productPage = allProductsPage.CreateProduct();
            productPage.InputProductName("eda");
            productPage.InputCategoryId("Beverages");
            productPage.InputSupplierId("Lyngbysild");
            productPage.InputUnitPrice("12");
            productPage.InputQuantityPerUnit("1");
            productPage.InputUnitsInStock("111");
            productPage.InputUnitsOnOrder("2");
            productPage.InputReorderLevel("1");
            productPage.Submit();

            Assert.AreEqual("All Products", productPage.TitleText());
            Assert.IsTrue(isElementPresent(By.XPath("//*[@class='table']//a[text()='eda']")));
        }

        [Test, Order(3)]
        public void CheckProduct()
        {
            productPage = allProductsPage.OpenProduct("eda");

            Assert.AreEqual(productPage.ReadProductName(), "eda");
            Assert.AreEqual(productPage.ReadCategoryId(), "Beverages");
            Assert.AreEqual(productPage.ReadSupplierId(), "Lyngbysild");
            Assert.AreEqual(productPage.ReadUnitPrice(), "12,0000");
            Assert.AreEqual(productPage.ReadQuantityPerUnit(), "1");
            Assert.AreEqual(productPage.ReadUnitsInStock(), "111");
            Assert.AreEqual(productPage.ReadUnitsOnOrder(), "2");
            Assert.AreEqual(productPage.ReadReorderLevel(), "1");

            productPage.ToAllProducts();
        }

        [Test, Order(4)]
        public void Delete()
        {
            allProductsPage.DeleteProduct("eda");
            allProductsPage.WaitLoading(driver);
            Assert.IsFalse(allProductsPage.IsProductPresent("eda", driver));
        }

        [Test, Order(5)]
        public void Logout()
        {
            loginPage = allProductsPage.Logout();
            Assert.AreEqual("Login", loginPage.TitleText());

        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}