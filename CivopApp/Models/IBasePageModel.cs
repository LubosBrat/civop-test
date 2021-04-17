using CivopApp.Core;

namespace CivopApp.Models
{
    /// <summary>
    /// Base model interface for methods and properties available in all pages
    /// </summary>
    public interface IBasePageModel
    {
        /// <summary>
        /// Database context
        /// </summary>
        IAppDbContext DbContext { get; }
    }
}
