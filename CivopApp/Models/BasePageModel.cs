using CivopApp.Core;

namespace CivopApp.Models
{
    /// <inheritdoc/>
    public class BasePageModel : IBasePageModel
    {
        public IAppDbContext DbContext { get; }

        public BasePageModel(IAppDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}