using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Http;
using System.Diagnostics;
using System.Web.Http.Tracing;

namespace BootstrapMVC.App_Start
{
    public class WebAPIConfig
    {
        public static void Register(HttpConfiguration config)
        
        {
            config.EnableSystemDiagnosticsTracing();

            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
            traceWriter.MinimumLevel = System.Web.Http.Tracing.TraceLevel.Info;


            config.Routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
        }
    }
}