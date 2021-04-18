using System.Collections.Generic;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public class OrderViewMock : PageMockBase, IOrderView
    {
        public string CustomerName { get; set; }
        public string CustomerPostAddress { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public float Quantity { get; set; }
        public IList<OrderProduct> Products { get; set; }
        public IList<Product> AllProducts { get; set; }
    }
}
