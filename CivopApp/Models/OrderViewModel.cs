using System;
using System.Linq;
using CivopApp.Domain;

namespace CivopApp.Models
{
    /// <summary>
    /// View model for displaying <see cref="Order"/> information in list
    /// </summary>
    public class OrderViewModel
    {
        public OrderViewModel(Order o)
        {
            Id = o.Id;
            CustomerName = o.CustomerName;
            CustomerPostAddress = o.CustomerPostAddress;
            UtcDateCreated = o.UtcDateCreated;
            ProductsCount = o.Products.Sum(x => x.Quantity);
            TotalPrice = o.Products.Sum(x => Convert.ToDecimal(x.Quantity) * x.Product.Price);
        }

        /// <summary>
        /// Primary key of the Order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer, assuming both First and Last name is joined to one field for simplicity
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Postal address of the customer
        /// </summary>
        public string CustomerPostAddress { get; set; }

        /// <summary>
        /// Creation date of the order in UTC
        /// </summary>
        public DateTime UtcDateCreated { get; set; }

        /// <summary>
        /// Total number of quantities of products attached to the <see cref="Order"/>
        /// </summary>
        public float ProductsCount { get; set; }

        /// <summary>
        /// Total price of the order
        /// </summary>
        public decimal TotalPrice { get; set; }

    }
}