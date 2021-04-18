using CivopApp.Core;
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
    }
}