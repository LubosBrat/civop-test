using CivopApp.Core;
using CivopApp.Presenters;
using CivopApp.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Presenters
{
    [TestClass]
    public class ProductsPresenterTest
    {
        private ProductsPresenter _presenter;
        private ProductsPageMock _viewMock;
        private IAppDbContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            TestDbContext.ClearData();
            _dbContext = TestDbContext.Instance;
            CreateTestData();
            _viewMock = new ProductsPageMock();

            _presenter = new ProductsPresenter(_viewMock, _dbContext);
        }


        [TestMethod]
        public void LoadProducts()
        {
            Assert.IsNull(_viewMock.Data);
            _presenter.LoadProducts();
            Assert.AreEqual(1, _viewMock.Data.Count);
        }


        private void CreateTestData()
        {
            _dbContext.Products.Add(TestCommon.TestProduct1);
            _dbContext.SaveChanges();
        }

    }
}
