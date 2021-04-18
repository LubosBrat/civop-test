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

        [TestInitialize]
        public void Setup()
        {
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
    }
}
