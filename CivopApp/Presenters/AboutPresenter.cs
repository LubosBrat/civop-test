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
            _view.Title = "O společnosti CIVOP";
            _view.MetaDescription = "Společnost zahájila činnost v Praze v roce 1993 jako malá rodinná firma. ";
            _view.Text = @"<p>To umožnilo společnosti vyrůst postupně na jednu z největších firem v oboru  a se zodpovědností za více než cca 6.500 pracovišť našich klientů na celém území ČR a SR.</p>
                        <p>Aktuálně dáváme velký důraz na synergii všech našich základních služeb BOZP, PO, ŽP a revizí.Principem je aby měl klient vše řízeno z jednoho bodu na stejné úrovni kvality a v jednotném systému, kterým je unikátní Civop System.</p>";
        }
    }
}