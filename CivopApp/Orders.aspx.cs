using System;
using System.Collections.ObjectModel;
using CivopApp.Models;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    /// <inheritdoc cref="IOrdersView"/>
    public partial class Orders : BasePage, IOrdersView
    {
        private readonly OrdersPresenter _presenter;

        public Orders()
        {
            _presenter = new OrdersPresenter(this, DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.OnLoadPage();
            GridView1.DataSource = Data;
            GridView1.DataBind();
        }

        public ObservableCollection<OrderViewModel> Data { get; set; }
    }
}