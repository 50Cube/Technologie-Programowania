using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3sql;
using System.Linq;
using System.IO;

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
            Assert.AreEqual(value, 92092);
        }

        [TestMethod]
        public void TestGetProductsWithoutCategoryDeclarative()
        {
            List<Product> list = ExtensionMethods.GetProductsWithoutCategoryDeclarative();
            Assert.AreEqual(list.Count, 209);
        }

        [TestMethod]
        public void TestGetProductsWithoutCategoryImperative()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> list = (from product in db.Products
                                                  select product).ToList();
                
            list = ExtensionMethods.GetProductsWithoutCategoryImperative(list);
            Assert.AreEqual(list.Count, 209);
            }
        }

        [TestMethod]
        public void TestGetProductsAndVendors()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Product> products = (from product in db.Products
                                      select product).ToList();

                List<ProductVendor> vendors = (from vendor in db.ProductVendors
                                          select vendor).ToList();

                string result = ExtensionMethods.GetProductsAndVendors(products, vendors);
                string first = new StringReader(result).ReadLine();
                Assert.AreEqual(first, "Adjustable Race-Litware, Inc.");
            }
        }
    }
}
