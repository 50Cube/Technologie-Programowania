using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3sql;
using System.Data.Linq;
using System.Linq;

namespace Zadanie3TestProject
{
    [TestClass]
    public class DBServiceTest
    {
        [TestMethod]
        public void TestGetProductsByName()
        {
            List<Product> list = DBService.GetProductsByName("Blade");
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].ProductID, 316);
            Assert.AreEqual(list[0].Name, "Blade");
        }

        [TestMethod]
        public void TestGetProductsByVendorName()
        {
            List<Product> list = DBService.GetProductsByVendorName("International");
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].ProductID, 462);
        }

        [TestMethod]
        public void TestGetProductNamesByVendorName()
        {
            List<string> list = DBService.GetProductNamesByVendorName("International");
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0], "Lower Head Race");
        }

        [TestMethod]
        public void TestGetProductVendorByProductName()
        {
            String name = DBService.GetProductVendorByProductName("Lower Head Race");
            Assert.AreEqual(name, "International");
        }

        [TestMethod]
        public void TestGetProductsWithNRecentReviews()
        {
            List<Product> list = DBService.GetProductsWithNRecentReviews(2);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].ProductID, 709);
            Assert.AreEqual(list[1].ProductID, 937);
        }

        [TestMethod]
        public void TestGetNRecentlyReviewedProducts()
        {
            List<Product> list = DBService.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0].ProductID, 709);
            Assert.AreEqual(list[1].ProductID, 937);
            Assert.AreEqual(list[2].ProductID, 937);
        }

        [TestMethod]
        public void TestGetNProductsFromCategory()
        {
            List<Product> list = DBService.GetNProductsFromCategory("Bikes", 4);
            Assert.AreEqual(list.Count, 4);
            Assert.AreEqual(list[0].ProductID, 771);
            Assert.AreEqual(list[1].ProductID, 772);
            Assert.AreEqual(list[2].ProductID, 773);
            Assert.AreEqual(list[3].ProductID, 774);
        }

        [TestMethod]
        public void TestGetTotalStandardCostByCategory()
        {
            int value = 0;
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<ProductCategory> category = (from cat in db.ProductCategories
                                                  where cat.Name.Equals("Bikes")
                                                  select cat).ToList();

                value = DBService.GetTotalStandardCostByCategory(category[0]);
            }
            Assert.AreEqual(value, 92040);
        }
    }
}
