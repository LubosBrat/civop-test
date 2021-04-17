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
    public class ProductsPresenter
    {
        private readonly IProductsView _view;
        private readonly IAppDbContext _dbContext;

        public ProductsPresenter(IProductsView view, IAppDbContext dbContext)
        {
            _view = view;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads products from DB to Datasource
        /// </summary>
        public void LoadProducts()
        {
            var products = _dbContext.Products.ToList();
            _view.Data = new ObservableCollection<Product>(products);
        }
    }
}