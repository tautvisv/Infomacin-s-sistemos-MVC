﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OroUostoSistema.DatabaseOroUostas;

namespace OroUostoSistema
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
             AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); //I AM THE 2nd
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<DB>(new DropCreateDatabaseIfModelChanges<DB>());
           
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}