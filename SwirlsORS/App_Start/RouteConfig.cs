using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BootstrapMVC
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
             name: "Stores",
             url: "{controller}/{action}/{sortBy}",
             defaults: new { controller = "Stores", action = "Index", sortBy = UrlParameter.Optional }
             );

            routes.MapRoute(
       name: "Stores1",
       url: "{controller}/{action}/{searchText}",
       defaults: new { controller = "Stores", action = "Index", searchOption = UrlParameter.Optional, searchText = UrlParameter.Optional }
   );

        }
    }

}