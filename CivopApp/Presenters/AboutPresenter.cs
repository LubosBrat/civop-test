using CivopApp.Views;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Presenter for About page
    /// </summary>
    public class AboutPresenter
    {
        private readonly IAboutView _view;

        public AboutPresenter(IAboutView view)
        {
            _view = view;
        }

        /// <summary>
        /// Initializes page properties
        /// </summary>
        public void Init()
        {
            _view.Title = "O CIVOP aplikaci";
            _view.MetaDescription = "Toto je testovací stránka o aplikaci CIVOP. Meta description";
            _view.Text = "Textový popisek stránky :-). Nastavení obsahu pokryto testy.";
        }
    }
}