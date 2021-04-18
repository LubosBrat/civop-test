using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public abstract class PageMockBase : IPageViewBase
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
    }
}
