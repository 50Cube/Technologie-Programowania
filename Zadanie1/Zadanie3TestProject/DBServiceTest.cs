using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3sql;

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
    }
}
