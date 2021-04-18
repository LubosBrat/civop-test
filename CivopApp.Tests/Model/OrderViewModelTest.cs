using CivopApp.Domain;
using CivopApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Model
{
    [TestClass]
    public class OrderViewModelTest
    {
        private OrderViewModel _model;
        private Order _testOrder;

        [TestInitialize]
        public void Setup()
        {
            _testOrder = TestCommon.TestOrder1;
            _model = new OrderViewModel(_testOrder);
        }

        [TestMethod]
        public void Ctor_SetsProperties()
        {
            Assert.AreEqual(_testOrder.Id, _model.Id);
            Assert.AreEqual(_testOrder.CustomerName, _model.CustomerName);
            Assert.AreEqual(_testOrder.CustomerPostAddress, _model.CustomerPostAddress);
            Assert.AreEqual(_testOrder.UtcDateCreated, _model.UtcDateCreated);
            
        }

        [TestMethod]
        public void Ctor_ComputesProducts()
        {
            _testOrder.Products.Add(new OrderProduct()
            {
                OrderId = 1,
                Product = TestCommon.TestProduct1,
                ProductId = TestCommon.TestProduct1.Id,
                Quantity = 5
            });
            _model = new OrderViewModel(_testOrder);
            Assert.AreEqual(5, _model.ProductsCount);
            Assert.AreEqual(50m, _model.TotalPrice);
        }

    }
}
