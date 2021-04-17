using System;
using System.Collections.ObjectModel;
using CivopApp.Core;
using CivopApp.Domain;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    public partial class Products : BasePage, IProductsView
    {
        private readonly ProductsPresenter _presenter;

        public Products()
        {
            _presenter = new ProductsPresenter(this, new AppDbContext());
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.LoadProducts();
            GridView1.DataSource = Data;
            GridView1.DataBind();
        }

        public ObservableCollection<Product> Data { get; set; }
    }
}