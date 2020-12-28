using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverAdv.PO;
using WebDriverAdv.business_objects;
using WebDriverAdv.service;

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
        private Product eda = new Product("eda", "Beverages", "Lyngbysild", "12", "1", "111", "2", "1");
        private ProductServices productServices;

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
            Assert.AreEqual("Home page", homePage.TitleText());
        }

        [Test, Order(2)]
        public void Add()
        {
            productServices = new ProductServices();
            productPage = new ProductPage(driver);
            productServices.InputProduct(eda, driver);
            allProductsPage = new AllProductsPage(driver);

            Assert.AreEqual("All Products", productPage.TitleText());
            Assert.IsTrue(allProductsPage.IsProductPresent(eda.productName));
        }

        [Test, Order(3)]
        public void CheckProduct()
        {
            Product productCheck = productServices.ReadProduct(eda, driver);            
            Assert.AreEqual(eda.productName, productCheck.productName);
            Assert.AreEqual(eda.categoryId, productCheck.categoryId);
            Assert.AreEqual(eda.supplierId, productCheck.supplierId);
            Assert.AreEqual(eda.unitPrice, productCheck.unitPrice);
            Assert.AreEqual(eda.quantityPerUnit, productCheck.quantityPerUnit);
            Assert.AreEqual(eda.unitsInStock, productCheck.unitsInStock);
            Assert.AreEqual(eda.unitsOnOrder, productCheck.unitsOnOrder);
            Assert.AreEqual(eda.reorderLevel, productCheck.reorderLevel);
            productPage.ToAllProducts();
        }

        [Test, Order(4)]
        public void Delete()
        {
            productServices.DeleteProduct(eda, driver);
            Assert.IsFalse(allProductsPage.IsProductPresent(eda.productName));
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