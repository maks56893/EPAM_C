using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using WebDriverAdv.PO;
using WebDriverAdv.business_objects;

namespace WebDriverAdv.service
{
    class ProductServices
    {
        ProductPage productPage;
        AllProductsPage allProductsPage;
        private IWebDriver driver;

       /*public ProductServices(IWebDriver driver)
        {
            this.driver = driver;
        }*/
        public void InputProduct(Product product, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage = new HomePage(driver);
            allProductsPage = homePage.ClickOnLink("All Products");
            productPage = allProductsPage.CreateProduct();
            productPage.InputProductName(product.productName);
            productPage.InputCategoryId(product.categoryId);
            productPage.InputSupplierId(product.supplierId);
            productPage.InputUnitPrice((product.unitPrice).ToString());
            productPage.InputQuantityPerUnit(product.quantityPerUnit);
            productPage.InputUnitsInStock(product.unitsInStock);
            productPage.InputUnitsOnOrder(product.unitsOnOrder);
            productPage.InputReorderLevel(product.reorderLevel);
            productPage.Submit();
        }

        public Product ReadProduct(Product product, IWebDriver driver)
        {
            allProductsPage = new AllProductsPage(driver);
            productPage = allProductsPage.OpenProduct(product.productName);
            string productName = productPage.ReadProductName();
            string categoryId = productPage.ReadCategoryId();
            string supplierId = productPage.ReadSupplierId();
            string unitPrice = Convert.ToDouble(productPage.ReadUnitPrice()).ToString();
            string quantityPerUnit = productPage.ReadQuantityPerUnit();
            string unitsInStock = productPage.ReadUnitsInStock();
            string unitsOnOrder = productPage.ReadUnitsOnOrder();
            string reorderLevel = productPage.ReadReorderLevel();
            return new Product(productName, categoryId, supplierId, unitPrice, quantityPerUnit, unitsInStock, unitsOnOrder, reorderLevel);
        }
        public void DeleteProduct(Product product, IWebDriver driver)
        {
            productPage = new ProductPage(driver);
            
            allProductsPage.DeleteProduct(product.productName);

        }
    }
}
