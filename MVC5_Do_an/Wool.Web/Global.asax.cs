using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Wool.Data;
using Wool.Web.App_Start;

namespace Wool.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new StoreSeedData());
            using (var context = new WoolEntities())
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<WoolEntities>());
                context.Database.Initialize(true);
            }
                AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
