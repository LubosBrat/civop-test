using System.ComponentModel.DataAnnotations;

namespace CivopApp.Domain
{
    /// <summary>
    /// Cross Order-Product entity holding information about <see cref="Product"/> attached to <see cref="Order"/> together with Quantity
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Primary key of the record
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to Products table
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Attached <see cref="Product"/> entity
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Foreign key to Orders table
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Attached Order entity
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Quantity with information how many <see cref="Product"/>s are attached to particular <see cref="Order"/>
        /// </summary>
        public float Quantity { get; set; }
    }
}