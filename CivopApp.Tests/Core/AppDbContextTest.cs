using System.Linq;
using CivopApp.Core;
using CivopApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Core
{
    [TestClass]
    public class AppDbContextTest
    {
        private Product _testProduct;
        private IAppDbContext _testDbContext;

        [TestInitialize]
        public void Setup()
        {
            _testDbContext = TestDbContext.Instance;
            _testProduct = TestCommon.TestProduct1;
            TestDbContext.ClearData();
        }

        [TestMethod]
        public void Products_CanAddNewProduct()
        {
            StoreTestProduct();
            var storedProducts = _testDbContext.Products.ToList();
            Assert.AreEqual(1, storedProducts.Count);
        }

        [TestMethod]
        public void Products_CanBeUpdated()
        {
            var newCode = "Changed code";
            StoreTestProduct();
            var storedProduct = _testDbContext.Products.Find(_testProduct.Id);
            Assert.AreEqual(_testProduct.Code, storedProduct.Code);
            storedProduct.Code = newCode;
            _testDbContext.SaveChanges();
            var updatedProduct = _testDbContext.Products.Find(_testProduct.Id);
            Assert.AreEqual(newCode, updatedProduct.Code);
        }

        private void StoreTestProduct()
        {
            _testDbContext.Products.Add(_testProduct);
            _testDbContext.SaveChanges();
        }
    }
}
