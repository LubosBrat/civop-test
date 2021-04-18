using CivopApp.Presenters;
using CivopApp.Tests.Mock;
using CivopApp.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CivopApp.Tests.Presenters
{
    [TestClass]
    public class OrdersPresenterTest
    {
        private OrdersPresenter _presenter;
        private IOrdersView _viewMock;

        [TestInitialize]
        public void Setup()
        {
            _viewMock = new OrdesViewMock();
            _presenter = new OrdersPresenter(_viewMock, TestDbContext.Instance);
        }

        [TestMethod]
        public void OnLoadPage_SetsProperties()
        {
            Assert.IsTrue(string.IsNullOrEmpty(_viewMock.Title));
            _presenter.OnLoadPage();
            Assert.IsFalse(string.IsNullOrEmpty(_viewMock.Title));
        }

        [TestMethod]
        public void OnLoadPage_LoadsOrders()
        {
            Assert.IsNull(_viewMock.Data);
            _presenter.OnLoadPage();
            Assert.IsNotNull(_viewMock.Data);
        }


    }
}
