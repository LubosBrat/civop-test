using System.Collections.ObjectModel;
using CivopApp.Domain;

namespace CivopApp.Views
{
    public interface IProductsView : IPageViewBase
    {
        /// <summary>
        /// List of products
        /// </summary>
        ObservableCollection<Product> Data { get; set; }
    }
}
