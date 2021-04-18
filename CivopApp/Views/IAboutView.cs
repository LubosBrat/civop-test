namespace CivopApp.Views
{
    /// <summary>
    /// About page
    /// </summary>
    public interface IAboutView : IPageViewBase
    {
        /// <summary>
        /// Page text
        /// </summary>
        string Text { get; set; }
    }
}
