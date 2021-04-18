using System;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using CivopApp.Core;
using CivopApp.Domain;
using CivopApp.Views;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Presenter for <see cref="ProductPage"/>
    /// </summary>
    public class ProductPresenter : PresenterBase
    {
        private readonly IProductView _view;

        public ProductPresenter(IProductView view, IAppDbContext dbContext) : base(dbContext)
        {
            _view = view;
        }

        public override void OnLoadPage()
        {
            _view.Title = "Detail produktu";
        }

        public void LoadProduct(string productId)
        {
            if (string.IsNullOrEmpty(productId)) return;
            _view.Product = DbContext.Products.Find(Convert.ToInt32(productId));
            if (_view.Product == null) return;
            _view.ProductId = _view.Product.Id;
            _view.ProductCode = _view.Product.Code;
            _view.ProductName = _view.Product.Name;
            _view.ProductPrice = _view.Product.Price;
        }

        public void SaveProduct()
        {
            var savedProduct = _view.ProductId == null 
                ? new Product() 
                : DbContext.Products.Find(_view.ProductId);

            if (savedProduct == null)
                throw new ObjectNotFoundException("Ukládaný produkt nexistuje v databázi");

            ReadsForm(savedProduct);
            DbContext.Products.AddOrUpdate(savedProduct);
            DbContext.SaveChanges();
        }

        private void ReadsForm(Product product)
        {
            product.Name = _view.ProductName;
            product.Code = _view.ProductCode;
            product.Price = _view.ProductPrice;
        }
    }
}