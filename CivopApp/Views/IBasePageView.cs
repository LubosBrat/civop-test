namespace CivopApp.Views
{
    /// <summary>
    /// Base interface for all pages
    /// </summary>
    public interface IPageViewBase
    {
        /// <summary>
        /// Page title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Page meta-description
        /// </summary>
        string MetaDescription { get; set; }
      
    }
}
