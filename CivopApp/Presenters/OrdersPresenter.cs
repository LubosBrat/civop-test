using System.Collections.ObjectModel;
using System.Linq;
using CivopApp.Core;
using CivopApp.Domain;
using CivopApp.Models;
using CivopApp.Views;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Presenter for <see cref="Orders"/> page
    /// </summary>
    public class OrdersPresenter : PresenterBase
    {
        private readonly IOrdersView _view;

        public OrdersPresenter(IOrdersView view, IAppDbContext dbContext) : base(dbContext)
        {
            _view = view;
        }

        public override void OnLoadPage()
        {
            _view.Title = "Objednávky";
            _view.MetaDescription = "Objednávky";
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = DbContext.Orders.Include("Products").ToList().Select(x => new OrderViewModel(x)).ToList();
            _view.Data = new ObservableCollection<OrderViewModel>(orders);
        }


    }
}