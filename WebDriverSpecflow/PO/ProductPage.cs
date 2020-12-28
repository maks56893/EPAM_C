using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverAdv.PO
{
    class ProductPage
    {
        private IWebDriver driver;
        public IWebElement submitBtn => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement toAllProductsBtn => driver.FindElement(By.XPath("//a[text()=\"Products\"]"));
        private IWebElement productNameInput => driver.FindElement(By.Id("ProductName"));
        private IWebElement CategoryIdSelect => driver.FindElement(By.Id("CategoryId"));
        private IWebElement SupplierIdSelect => driver.FindElement(By.Id("SupplierId"));
        private IWebElement unitPriceInput => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement quantityPerUnitInput => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement unitsInStockInput => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement unitsOnOrderInput => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement reorderLevelInput => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement Title => driver.FindElement(By.XPath("//h2"));

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void InputProductName(string key)
        {
            productNameInput.SendKeys(key);
        }
        public void InputCategoryId(string value)
        {
            SelectElement select = new SelectElement(CategoryIdSelect);
            select.SelectByText(value);
        }
        public void InputSupplierId(string value)
        {
            SelectElement select = new SelectElement(SupplierIdSelect);
            select.SelectByText(value);
        }
        public void InputUnitPrice(string key)
        {
            unitPriceInput.SendKeys(key);
        }
        public void InputQuantityPerUnit(string key)
        {
            quantityPerUnitInput.SendKeys(key);
        }
        public void InputUnitsInStock(string key)
        {
            unitsInStockInput.SendKeys(key);
        }
        public void InputUnitsOnOrder(string key)
        {
            unitsOnOrderInput.SendKeys(key);
        }
        public void InputReorderLevel(string key)
        {
            reorderLevelInput.SendKeys(key);
        }
        public void Submit()
        {
            submitBtn.Click();
        }
        public string TitleText()
        {
            return Title.Text;
        }

        /////////////////////////////////////////////////
        public string ReadProductName()
        {
            return productNameInput.GetAttribute("value");
        }
        public string ReadCategoryId()
        {
            SelectElement select = new SelectElement(CategoryIdSelect);
            return select.SelectedOption.Text;
        }
        public string ReadSupplierId()
        {
            SelectElement select = new SelectElement(SupplierIdSelect);
            return select.SelectedOption.Text;
        }

        public string ReadUnitPrice()
        {
            return unitPriceInput.GetAttribute("value");
        }

        public string ReadQuantityPerUnit()
        {
            return quantityPerUnitInput.GetAttribute("value");
        }

        public string ReadUnitsInStock()
        {
            return unitsInStockInput.GetAttribute("value");
        }

        public string ReadUnitsOnOrder()
        {
            return unitsOnOrderInput.GetAttribute("value");
        }

        public string ReadReorderLevel()
        {
            return reorderLevelInput.GetAttribute("value");
        }
        public AllProductsPage ToAllProducts()
        {
            toAllProductsBtn.Click();
            return new AllProductsPage(driver);
        }
    }
}
