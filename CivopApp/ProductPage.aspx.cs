using System;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    /// <summary>
    /// <inheritdoc cref="IProductView"/>
    /// </summary>
    public partial class ProductPage : BasePage, IProductView
    {
        private readonly ProductPresenter _presenter;

        public ProductPage()
        {
            _presenter = new ProductPresenter(this, DbContext);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.OnLoadPage();
        }
    }
}