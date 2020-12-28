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
            productPage = allProductsPage.OpenProduct(product.productName);

            Product product2 = new Product
            {
                productName = productPage.ReadProductName(),
                categoryId = productPage.ReadCategoryId(),
                supplierId = productPage.ReadSupplierId(),
                unitPrice = (Convert.ToDouble(productPage.ReadUnitPrice())).ToString(),
                quantityPerUnit = productPage.ReadQuantityPerUnit(),
                unitsInStock = productPage.ReadUnitsInStock(),
                unitsOnOrder = productPage.ReadUnitsOnOrder(),
                reorderLevel = productPage.ReadReorderLevel()                
            };
            return product2;
        }
        public void DeleteProduct(Product product, IWebDriver driver)
        {
            productPage = new ProductPage(driver);
            
            allProductsPage.DeleteProduct(product.productName);
            allProductsPage.WaitLoading(driver, product.productName);

        }
    }
}
