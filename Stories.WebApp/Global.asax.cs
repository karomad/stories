using Stories.DataModels.Entities;
using Stories.DataModels.Migrations;
using Stories.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Stories.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoriesDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DIConfig.Run();
        }

        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    string currentUrl = HttpContext.Current.Request.Path.ToLower();

        //    if (HttpContext.Current != null &&
        //        HttpContext.Current.Session != null &&
        //        SessionManager.CurrentUser == null &&
        //        !currentUrl.Contains("/user/login") &&
        //        !currentUrl.Contains("/user/logout"))
        //    {
        //        var context = new HttpContextWrapper(HttpContext.Current);
        //        if (context.Request.IsAjaxRequest())
        //        {
        //            HttpContext.Current.Response.Clear();
        //            HttpContext.Current.Response.StatusCode = 401;
        //        }
        //        else
        //        {
        //            HttpContext.Current.Response.Redirect("~/User/Login");
        //        }
        //    }
        //}
    }
}
