using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverAdv.business_objects;
using WebDriverAdv.PO;
using WebDriverAdv.service;

namespace WebDriverAdv.step_definitions
{
    [Binding]
    class ProductCreation
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private ProductPage productPage;
        private AllProductsPage allProductsPage;
        [Given(@"I login to ""(.+)""")]
        public void GivenIOpenLoginPage(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            loginPage.Login("user", "user");
        }
        [When(@"I click on ""(.+)"" button")]
        public void WhenIClickOnAllProductButton(string link)
        {
            homePage = new HomePage(driver);
            homePage.ClickOnLink(link);
        }
        [When(@"I click on Create New button")]
        public void WhenIClickOnCreateNew()
        {
            allProductsPage = new AllProductsPage(driver);
            allProductsPage.CreateNewProduct();
        }
        [When(@"I enter values of new product ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)"", ""(.+)""")]
        public void WhenIEnterProductValues(string productName, string categoryId, string supplierId, string unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel)
        {
            productPage = new ProductPage(driver);
            productPage.InputProductName(productName);
            productPage.InputCategoryId(categoryId);
            productPage.InputSupplierId(supplierId);
            productPage.InputUnitPrice(unitPrice);
            productPage.InputQuantityPerUnit(quantityPerUnit);
            productPage.InputUnitsInStock(unitsInStock);
            productPage.InputUnitsOnOrder(unitsOnOrder);
            productPage.InputReorderLevel(reorderLevel);
        }
        [When(@"I click on Send button")]
        public void WhenIClickSendButton()
        {
            productPage.Submit();
        }
        [Then(@"A product named ""(.+)"" should appear on the all product page")] 
        public void ThenAProductNamedShouldAppearOnTheProductPage(string name)
        {
            Assert.IsTrue(allProductsPage.IsProductPresent(name));
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }



    }
}
