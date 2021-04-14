using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CivopApp.Domain
{
    /// <summary>
    /// Simple Order entity
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Primary key of the Order
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the customer, assuming both First and Last name is joined to one field for simplicity
        /// </summary>
        [StringLength(255)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Postal address of the customer
        /// </summary>
        [StringLength(255)]
        public string CustomerPostAddress { get; set; }

        /// <summary>
        /// Creation date of the order in UTC
        /// </summary>
        public DateTime UtcDateCreated { get; set; }

        /// <summary>
        /// Items - products attached to the order
        /// </summary>
        public ICollection<OrderProduct> Products { get; set; }
    }
}