using System.Collections.Generic;
using CivopApp.Domain;

namespace CivopApp.Views
{
    /// <summary>
    /// Interface of the <see cref="OrderPage"/>
    /// </summary>
    public interface IOrderView : IPageViewBase
    {
        /// <summary>
        /// Name of the customer
        /// </summary>
        string CustomerName { get; set; }

        /// <summary>
        /// Customers post address
        /// </summary>
        string CustomerPostAddress { get; set; }

        /// <summary>
        /// Id of current <see cref="Order"/>. Is null for new Order creation 
        /// </summary>
        int? OrderId { get; set; }

        /// <summary>
        /// Selected product Id
        /// </summary>
        int? ProductId { get; set; }

        /// <summary>
        /// Quantity of <see cref="Product"/> appended to the Order
        /// </summary>
        float Quantity { get; set; }

        /// <summary>
        /// Products attached to the <see cref="Order"/>
        /// </summary>
        IList<OrderProduct> Products { get; set; }

        /// <summary>
        /// Datasource for AppendProduct dropdown
        /// </summary>
        IList<Product> AllProducts { get; set; }
    }
}
