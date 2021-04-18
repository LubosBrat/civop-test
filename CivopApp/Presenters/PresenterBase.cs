using CivopApp.Core;

namespace CivopApp.Presenters
{
    /// <summary>
    /// Parent of all presenters working with DB Context
    /// </summary>
    public abstract class PresenterBase
    {
        protected IAppDbContext DbContext { get; }

        protected PresenterBase(IAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Initializatinos for calling in Page_Load methods
        /// </summary>
        public abstract void OnLoadPage();
    }
}