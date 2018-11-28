using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventPlanner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            StripeConfiguration.SetApiKey("sk_test_6BExoTM2pg0bBuOClb0n5apM");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
