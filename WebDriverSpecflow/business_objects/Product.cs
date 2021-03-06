﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverAdv.business_objects
{
    class Product
    {
        public string productName;
        public string categoryId;
        public string supplierId;
        public string unitPrice;
        public string quantityPerUnit;
        public string unitsInStock;
        public string unitsOnOrder;
        public string reorderLevel;
        
        public Product(string productName, string categoryId, string supplierId, string unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string reorderLevel)
        {
            this.productName = productName;
            this.categoryId = categoryId;
            this.supplierId = supplierId;
            this.unitPrice = unitPrice;
            this.quantityPerUnit = quantityPerUnit;
            this.unitsInStock = unitsInStock;
            this.unitsOnOrder = unitsOnOrder;
            this.reorderLevel = reorderLevel;            
        }
        public Product()
        { }
    }
}
