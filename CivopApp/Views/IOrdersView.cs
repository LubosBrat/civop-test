using System.Collections.ObjectModel;
using CivopApp.Models;

namespace CivopApp.Views
{
    /// <summary>
    /// Orders displayed in table
    /// </summary>
    public interface IOrdersView : IPageViewBase
    {
        /// <summary>
        /// List of orders 
        /// </summary>
        ObservableCollection<OrderViewModel> Data { get; set; }
    }
}
