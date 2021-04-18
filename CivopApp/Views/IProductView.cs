using CivopApp.Domain;

namespace CivopApp.Views
{
    /// <summary>
    /// Interface for <see cref="ProductPage"/>
    /// </summary>
    public interface IProductView : IPageViewBase
    {
        /// <summary>
        /// Id produktu při editaci, null pokud jde o vytváření nového produktu
        /// </summary>
        Product Product { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        string ProductName { get; set; }

        /// <summary>
        /// Code of the product
        /// </summary>
        string ProductCode { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        decimal ProductPrice { get; set; }

        /// <summary>
        /// Id of the product
        /// </summary>
        int? ProductId { get; set; }
    }
}
