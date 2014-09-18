﻿using iwContactManager.Models.Validators;
using iwContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace iwContactManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.RegisterComponents(); 

            // custom model binders
            ModelBinders.Binders.Add(typeof(AValidator), new ValidatorModelBinder());
            //ModelBinders.Binders.Add(typeof(ValidatorViewModel), new ValidatorViewModelBinder());
        }
    }
}
