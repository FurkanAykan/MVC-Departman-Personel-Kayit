using Personel_MVC_SQL.App_Start;
using Personel_MVC_SQL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Personel_MVC_SQL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); // bütün site de bu authorizeri etkin yaptýk
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            bundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new ElmahExceptionFilter());
            GlobalFilters.Filters.Add(new HandleErrorAttribute());

        }
    }
}
