using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Xml.Linq;

namespace NetTraderSystem.Tests
{
    public class Tests
    {

        [Test]
        public void TradingPlatformInitialization()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            Assert.That(tradingPlatform, Is.Not.Null);
            Assert.That(tradingPlatform.Products, Is.Not.Null);
            Assert.That(tradingPlatform.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddProduct_WorksProperly()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product product = new Product(name, category, price);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Name, Is.EqualTo(name));
            Assert.That(product.Category, Is.EqualTo(category));
            Assert.That(product.Price, Is.EqualTo(price));

            string result = tradingPlatform.AddProduct(product);

            Assert.That(result, Is.EqualTo("Product Davidoff added successfully"));
            Assert.That(tradingPlatform.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddProduct_WorksProperly_TestLimit()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            for (int i = 0; i < inventoryLimit; i++)
            {
                Product product = new Product($"{i + 100}", $"{i + 200}", i + 300);
                tradingPlatform.AddProduct(product);

                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(i + 1));
            }
            Assert.That(tradingPlatform.Products.Count, Is.EqualTo(inventoryLimit));
        }

        [Test]
        public void AddProduct_WorksProperly_TestLimit_AndItsOverIt()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            for (int i = 0; i < inventoryLimit; i++)
            {
                Product product = new Product($"{i + 100}", $"{i + 200}", i + 300);
                tradingPlatform.AddProduct(product);

                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(i + 1));
            }

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product productOver = new Product(name, category, price);
            string result = tradingPlatform.AddProduct(productOver);

            Assert.That(result, Is.EqualTo("Inventory is full"));
        }

        [Test]
        public void RemoveProduct_WorksProperly_ButReturnsFlase()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            for (int i = 0; i < inventoryLimit; i++)
            {
                Product product = new Product($"{i + 100}", $"{i + 200}", i + 300);
                tradingPlatform.AddProduct(product);
                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(i + 1));
            }

            for (int i = 0; i < inventoryLimit; i++)
            {
                Product product = new Product($"{i + 100}", $"{i + 200}", i + 300);
                tradingPlatform.RemoveProduct(product);
            }

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product productOver = new Product(name, category, price);
            bool isFalse = tradingPlatform.RemoveProduct(productOver);
            Assert.That(isFalse, Is.False);
        }

        [Test]
        public void RemoveProduct_WorksProperly_ButReturnsFlase_WhenThereIsNoAdd()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product productOver = new Product(name, category, price);
            bool isFalse = tradingPlatform.RemoveProduct(productOver);
            Assert.That(isFalse, Is.False);
        }

        [Test]
        public void RemoveProduct_WorksProperly_ReturnsTrue()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product productOver = new Product(name, category, price);
            tradingPlatform.AddProduct(productOver);
            bool isFalse = tradingPlatform.RemoveProduct(productOver);
            Assert.That(isFalse, Is.True);
        }


        [Test]
        public void SellProduct_WorksProperly_ReturnsProduct()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product product = new Product(name, category, price);
            tradingPlatform.AddProduct(product);

            Product productToPurcahse = tradingPlatform.SellProduct(product);
            Assert.That(productToPurcahse, Is.Not.Null);
            Assert.That(productToPurcahse, Is.EqualTo(product));
            Assert.That(tradingPlatform.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellProduct_WorksProperly_ReturnsNull()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product product = new Product(name, category, price);

            tradingPlatform.AddProduct(product);

            string nameDuplicate = "Jacobs";
            string categoryDuplicate = "Nescaffe";
            double priceDuplicate = 5.50;
            Product productDuplicate = new Product(nameDuplicate, categoryDuplicate, priceDuplicate);

            Product productToPurcahse = tradingPlatform.SellProduct(productDuplicate);
            Assert.That(productToPurcahse, Is.Null);
            Assert.That(tradingPlatform.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void InventoryReport_WorksProperly()
        {
            int inventoryLimit = 5;
            TradingPlatform tradingPlatform = new TradingPlatform(inventoryLimit);

            string name = "Davidoff";
            string category = "Coffe";
            double price = 10.50;
            Product product = new Product(name, category, price);
            tradingPlatform.AddProduct(product);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: {tradingPlatform.Products.Count}");
            foreach (var productInColl in tradingPlatform.Products)
            {
                sb.AppendLine($"Name: {productInColl.Name}, Category: {productInColl.Category} - ${productInColl.Price:F2}");
            }

            string result = tradingPlatform.InventoryReport();

            Assert.That(result, Is.EqualTo(sb.ToString().Trim()));
        }
    }
}