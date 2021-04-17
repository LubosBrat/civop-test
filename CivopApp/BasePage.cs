using System;
using System.Web;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Web;
using CivopApp.Views;

namespace CivopApp
{
    public class BasePage : Page, IPageViewBase
    {
        protected override void OnInit(EventArgs e)
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectProperties(this);

            base.OnInit(e);
        }
    }
}