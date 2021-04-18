using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public class ProductPageMock : PageMockBase, IProductView
    {
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int? ProductId { get; set; }
    }
}
