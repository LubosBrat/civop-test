using CivopApp.Core;
using CivopApp.Views;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Presenter for About page
    /// </summary>
    public class AboutPresenter : PresenterBase
    {
        private readonly IAboutView _view;

        public AboutPresenter(IAboutView view, IAppDbContext dbContext) : base(dbContext)
        {
            _view = view;
        }


        public override void OnLoadPage()
        {
            _view.Title = "O CIVOP aplikaci";
            _view.MetaDescription = "Toto je testovací stránka o aplikaci CIVOP. Meta description";
            _view.Text = "Textový popisek stránky :-). Nastavení obsahu pokryto testy.";
        }
    }
}