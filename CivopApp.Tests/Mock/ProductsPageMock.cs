using System.Collections.ObjectModel;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public class ProductsPageMock : PageMockBase, IProductsView
    {
        public ObservableCollection<Product> Data { get; set; }
    }
}
