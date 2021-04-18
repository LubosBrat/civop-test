using System.Data.Entity.Migrations;
using System.Linq;
using CivopApp.Domain;
using CivopApp.Presenters;
using CivopApp.Tests.Mock;
using CivopApp.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Presenters
{
    [TestClass]
    public class OrderPresenterTest
    {
        private OrderPresenter _presenter;
        private IOrderView _viewMock;
        private Product _testProduct;
        private Product _testProduct2;
        private Order _testOrder;
        private Order _testOrder2;

        [TestInitialize]
        public void Setup()
        {
            _testOrder2 = TestCommon.TestOrder2;

            TestDbContext.ClearData();

            StoreTestProducts();
            StoreTestOrder();
            _viewMock = new OrderViewMock();
            _presenter = new OrderPresenter(_viewMock, TestDbContext.Instance);
        }

        [TestMethod]
        public void OnLoadPage_LoadsOrder()
        {
            _viewMock.OrderId = _testOrder.Id; 
            _presenter.OnLoadPage();
            Assert.AreEqual(_testOrder.Id, _viewMock.OrderId);
            Assert.AreEqual(_testOrder.CustomerName, _viewMock.CustomerName);
            Assert.AreEqual(_testOrder.CustomerPostAddress, _viewMock.CustomerPostAddress);
            Assert.AreEqual(1, _viewMock.Products.Count);
            Assert.AreEqual(2, _viewMock.AllProducts.Count);
        }

        [TestMethod]
        public void SaveOrder_StoresNewOrder()
        {
            var ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(1, ordersCount);
            _viewMock.CustomerName = _testOrder2.CustomerName;
            _viewMock.CustomerPostAddress = _testOrder2.CustomerPostAddress;
            _presenter.SaveOrder();
            ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(2, ordersCount);
        }

        [TestMethod]
        public void SaveOrder_StoresNewWithProduct()
        {
            var ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(1, ordersCount);
            var orderProductsCount = TestDbContext.Instance.OrderProducts.Count();
            Assert.AreEqual(1, orderProductsCount);

            _viewMock.CustomerName = _testOrder2.CustomerName;
            _viewMock.CustomerPostAddress = _testOrder2.CustomerPostAddress;
            _viewMock.ProductId = _testProduct.Id;
            _viewMock.Quantity = 10;
            _presenter.SaveOrder();

            ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(2, ordersCount);

            orderProductsCount = TestDbContext.Instance.OrderProducts.Count();
            Assert.AreEqual(2, orderProductsCount);
        }


        [TestMethod]
        public void SaveOrder_UpdatesOrder()
        {
            var ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(1, ordersCount);
            var orderProductsCount = TestDbContext.Instance.OrderProducts.Count();
            Assert.AreEqual(1, orderProductsCount);

            _viewMock.OrderId = _testOrder.Id;
            _viewMock.CustomerName = "New name";
            _viewMock.CustomerPostAddress = "New post address";
            _presenter.SaveOrder();

            ordersCount = TestDbContext.Instance.Orders.Count();
            Assert.AreEqual(1, ordersCount);
            orderProductsCount = TestDbContext.Instance.OrderProducts.Count();
            Assert.AreEqual(1, orderProductsCount);

            var savedOrder = TestDbContext.Instance.Orders.Find(_viewMock.OrderId);
            Assert.AreEqual("New name", savedOrder.CustomerName);
            Assert.AreEqual("New post address", savedOrder.CustomerPostAddress);
        }

        [TestMethod]
        public void SaveOrder_UpdatesExistingProduct()
        {
            _viewMock.OrderId = _testOrder.Id;
            _viewMock.ProductId = _testProduct.Id;
            _viewMock.Quantity = 100;
            _presenter.SaveOrder();

            var savedOrderProduct = TestDbContext.Instance.OrderProducts.FirstOrDefault(x =>
                x.ProductId == _viewMock.ProductId && x.OrderId == _viewMock.OrderId);

            Assert.AreEqual(100, savedOrderProduct.Quantity);
        }

        [TestMethod]
        public void SaveOrder_AddsNewOrderProduct()
        {
            _viewMock.OrderId = _testOrder.Id;
            _viewMock.ProductId = _testProduct2.Id;
            _viewMock.Quantity = 2;
            _presenter.SaveOrder();

            var savedOrder = TestDbContext.Instance.Orders.Include("Products")
                .FirstOrDefault(x => x.Id == _viewMock.OrderId);

            Assert.AreEqual(2, savedOrder.Products.Count);
        }


        private void StoreTestOrder()
        {
            _testOrder = TestCommon.TestOrder1;
            var orderProduct = new OrderProduct()
            {
                Product = _testProduct,
                Order = _testOrder,
                Quantity = 5
            };
            TestDbContext.Instance.Orders.Add(_testOrder);
            TestDbContext.Instance.OrderProducts.AddOrUpdate(orderProduct);
            TestDbContext.Instance.SaveChanges();
        }

        private void StoreTestProducts()
        {
            _testProduct = TestCommon.TestProduct1;
            _testProduct2 = TestCommon.TestProduct2;
            TestDbContext.Instance.Products.Add(_testProduct);
            TestDbContext.Instance.Products.Add(_testProduct2);
            TestDbContext.Instance.SaveChanges();
        }

     
    }
}
