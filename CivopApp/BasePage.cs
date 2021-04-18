using System;
using System.Web;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Forms;
using CivopApp.Core;
using CivopApp.Views;

namespace CivopApp
{
    [InjectProperties]
    public class BasePage : Page, IPageViewBase
    {
        private IAppDbContext _dbContext;
        protected IAppDbContext DbContext => _dbContext ?? (_dbContext = new AppDbContext());

        protected override void OnInit(EventArgs e)
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);

            base.OnInit(e);
        }
    }
}