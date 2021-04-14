using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivopApp.Domain
{
    /// <summary>
    /// Product, which can be attached to <see cref="Order"/> using <see cref="OrderProduct"/>
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique ID of the Product, primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Product code
        /// </summary>
        [StringLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}