using Stories.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stories.WebApp.Helpers
{
    public class SessionManager
    {
        public static UserViewModel CurrentUser
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    return HttpContext.Current.Session["CurrentUser"] as UserViewModel;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }
    }
}