using LegacyWebFormsApp01.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace LegacyWebFormsApp01
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}