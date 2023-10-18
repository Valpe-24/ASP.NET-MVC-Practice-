using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "Auth/Login",
                defaults: new { controller = "Auth", action = "Login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "Auth/Logout",
                defaults: new { controller = "Auth", action = "Logout" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Auth/Register",
                defaults: new { controller = "Auth", action = "Register" }
            );


            routes.MapRoute(
                name: "StudentDashboard",
                url: "Dashboard/{userId}",
                defaults: new { controller = "Dashboard", action = "Index", userId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TeacherDashboard",
                url: "Dashboard/{userId}",
                defaults: new { controller = "Dashboard", action = "Index", userId = UrlParameter.Optional }
            );



        }
    }
}
