using System.Linq;
using CivopApp.Domain;
using CivopApp.Presenters;
using CivopApp.Tests.Mock;
using CivopApp.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Presenters
{
    [TestClass]
    public class ProductPresenterTest
    {
        private ProductPresenter _presenter;
        private IProductView _viewMock;
        private Product _testProduct;

        [TestInitialize]
        public void Setup()
        {
            _testProduct = TestCommon.TestProduct1;
            TestDbContext.ClearData();
            _viewMock = new ProductPageMock();
            _presenter = new ProductPresenter(_viewMock,TestDbContext.Instance);
        }

        [TestMethod]
        public void OnLoadPage_SetsProperties()
        {
            _presenter.OnLoadPage();
            Assert.IsFalse(string.IsNullOrEmpty(_viewMock.Title));
        }

        [TestMethod]
        public void LoadProduct_LoadsProduct()
        {
            StoreTestProduct();

            Assert.IsNull(_viewMock.Product);
            _presenter.LoadProduct(_testProduct.Id.ToString());
            Assert.IsNotNull(_viewMock.Product);
            Assert.AreEqual(_viewMock.Product.Id, _testProduct.Id);
        }

        [TestMethod]
        public void LoadProduct_WorksWithNullId()
        {
            Assert.IsNull(_viewMock.Product);
            _presenter.LoadProduct(null);
            Assert.IsNull(_viewMock.Product);
        }

        [TestMethod]
        public void LoadProduct_FillsForm()
        {
            StoreTestProduct();
            _presenter.LoadProduct(_testProduct.Id.ToString());
            Assert.AreEqual(_viewMock.ProductId, _testProduct.Id);
            Assert.AreEqual(_viewMock.ProductCode, _testProduct.Code);
            Assert.AreEqual(_viewMock.ProductName, _testProduct.Name);
            Assert.AreEqual(_viewMock.ProductPrice, _testProduct.Price);
        }

        [TestMethod]
        public void SaveProduct_CreatesNewProduct()
        {
            InjectTestProductData();
            _presenter.SaveProduct();
            var products = TestDbContext.Instance.Products.ToList();
            Assert.AreEqual(1, products.Count);

            var savedProduct = products.First();
            Assert.AreEqual(_testProduct.Name, savedProduct.Name);
            Assert.AreEqual(_testProduct.Code, savedProduct.Code);
        }

        [TestMethod]
        public void SaveProduct_UpdatesCurrentProduct()
        {
            StoreTestProduct();
            var oldProductCode = _testProduct.Code;
            _viewMock.ProductId = _testProduct.Id;
            InjectTestProductData();
            _viewMock.ProductCode = "159kod753";
            _presenter.SaveProduct();
            var updatedProduct = TestDbContext.Instance.Products.Find(_testProduct.Id);

            Assert.AreEqual(_testProduct.Name, updatedProduct.Name);
            Assert.AreNotEqual(oldProductCode, updatedProduct.Code);

        }

        [TestMethod]
        public void DeleteProduct_RemovesProductFromDb()
        {
            StoreTestProduct();
            var productsTotal = TestDbContext.Instance.Products.Count();
            Assert.AreEqual(1, productsTotal);
            _viewMock.ProductId = _testProduct.Id;
            _presenter.DeleteProduct();
            productsTotal = TestDbContext.Instance.Products.Count();
            Assert.AreEqual(0, productsTotal);
        }

        private void InjectTestProductData()
        {
            _viewMock.ProductName = _testProduct.Name;
            _viewMock.ProductCode = _testProduct.Code;
            _viewMock.ProductPrice = _testProduct.Price;
        }

        private void StoreTestProduct()
        {
            TestDbContext.Instance.Products.Add(_testProduct);
            TestDbContext.Instance.SaveChanges();
        }
    }
}
