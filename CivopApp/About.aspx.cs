using System;
using CivopApp.Presenters;
using CivopApp.Views;

namespace CivopApp
{
    /// <inheritdoc cref="IAboutView"/>
    public partial class About : BasePage, IAboutView
    {
        private readonly AboutPresenter _presenter;

        public About()
        {
            _presenter = new AboutPresenter(this, DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.OnLoadPage();
        }

        /// <inheritdoc/>
        public string Text { get; set; }
    }
}