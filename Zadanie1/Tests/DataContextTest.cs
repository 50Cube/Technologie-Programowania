using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DataContextTest
    {
        private DataContext dataContext = new DataContext();

        [TestMethod]
        public void GetProductTest()
        {
            Product product = dataContext.Get(316);
            Assert.AreEqual(product.Name, "Blade");
        }

        [TestMethod]
        public void AddProductTest()
        {
            int size = dataContext.GetAll().Count();
            Product product = new Product
            {
                Name = "test",
                ProductNumber = "test",
                MakeFlag = true,
                FinishedGoodsFlag = true,
                Color = null,
                SafetyStockLevel = 1,
                ReorderPoint = 1,
                StandardCost = 1,
                ListPrice = 1,
                Size = null,
                SizeUnitMeasureCode = null,
                WeightUnitMeasureCode = null,
                Weight = null,
                DaysToManufacture = 1,
                ProductLine = null,
                Class = null,
                Style = null,
                ProductSubcategoryID = null,
                ProductModelID = null,
                SellStartDate = new DateTime(2020, 02, 02),
                SellEndDate = new DateTime(2020, 02, 02),
                rowguid = new Guid(),
                ModifiedDate = new DateTime(2020, 02, 02)
            };
            dataContext.Add(product);

            Assert.AreEqual(size + 1, dataContext.GetAll().Count());
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product product = dataContext.GetAll().First();
            product.Name = "zmieniony";
            dataContext.Update(product);
            Assert.AreEqual("zmieniony", dataContext.Get(product.ProductID).Name);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            List<Product> products = dataContext.GetAll().ToList();
            int size = dataContext.GetAll().Count();
            dataContext.Delete(dataContext.GetAll().Where(p => p.Name.Equals("test")).First());
            Assert.AreEqual(size - 1, dataContext.GetAll().Count());
        }
    }
}
