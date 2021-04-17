using System.Collections.ObjectModel;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public class ProductsPageMock : IProductsView
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public ObservableCollection<Product> Data { get; set; }
    }
}
