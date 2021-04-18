using CivopApp.Presenters;
using CivopApp.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CivopApp.Tests.Presenters
{
    [TestClass]
    public class AboutPresenterTest
    {
        private AboutPresenter _presenter;
        private Mock<IAboutView> _viewMock;
        
        [TestInitialize]
        public void Setup()
        {
            _viewMock = new Mock<IAboutView>();
            _presenter = new AboutPresenter(_viewMock.Object, TestDbContext.Instance);
        }

        [TestMethod]
        public void Init_SetsProperties()
        {
            _presenter.OnLoadPage();
            _viewMock.VerifySet(x => x.Title = It.IsAny<string>());
            _viewMock.VerifySet(x => x.MetaDescription = It.IsAny<string>());
            _viewMock.VerifySet(x => x.Text = It.IsAny<string>());
        }
    }
}
