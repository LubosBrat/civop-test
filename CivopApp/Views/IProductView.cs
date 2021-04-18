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

        string ProductName { get; set; }
        string ProductCode { get; set; }
        decimal ProductPrice { get; set; }
        int? ProductId { get; set; }
    }
}
