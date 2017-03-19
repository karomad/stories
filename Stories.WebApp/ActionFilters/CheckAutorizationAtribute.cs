using Stories.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stories.WebApp.ActionFilters
{
    public class CheckAutorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionManager.CurrentUser == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.StatusCode = 408;//custom status code unautorized
                    filterContext.Result = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}