using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        ViewModelClass vm = new ViewModelClass();

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(vm.AddProductCommand);
            Assert.IsNotNull(vm.DeleteCommand);
            Assert.IsNotNull(vm.UpdateProductCommand);
            Assert.IsNotNull(vm.ShowAddWindow);
            Assert.IsNotNull(vm.ShowUpdateWindow);
            Assert.IsNotNull(vm.RefreshList);
        }

        [TestMethod]
        public void AddProductTest()
        {
            int size = vm.Products.Count();
            
            vm.Name = "testvm";
            vm.ProductNumber = "testvm";
            vm.SellEndDate = DateTime.Now.Date.AddDays(1);

            vm.AddProductCommand.Execute(null);

            Assert.AreEqual(size + 1, vm.Products.Count());
            Assert.AreEqual(vm.Products.Last().Name, "testvm");
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            vm.ID = 1;
            vm.Name = "testupdatevm";
            vm.ProductNumber = "testupdatevm";

            vm.UpdateProductCommand.Execute(null);

            Assert.AreEqual(vm.Products.ElementAt(vm.ID - 1).Name, "testupdatevm");
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            int size = vm.Products.Count();
            vm.Product.ProductID = vm.Products.Last().ProductID;

            vm.DeleteCommand.Execute(null);

            Assert.AreEqual(size - 1, vm.Products.Count());
        }
    }
}
