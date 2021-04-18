using System.Collections.ObjectModel;
using System.Linq;
using CivopApp.Core;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Presenter for products
    /// </summary>
    public class ProductsPresenter : PresenterBase
    {
        private readonly IProductsView _view;

        public ProductsPresenter(IProductsView view, IAppDbContext dbContext) : base(dbContext)
        {
            _view = view;
        }

        /// <summary>
        /// Loads products from DB to Datasource
        /// </summary>
        public void LoadProducts()
        {
            var products = DbContext.Products.ToList();
            _view.Data = new ObservableCollection<Product>(products);
        }

        public override void OnLoadPage()
        {
            _view.Title = "Seznam produktů";
        }
    }
}