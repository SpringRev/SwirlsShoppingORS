using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Net.Http;
using BootstrapMVC.App_Start;
using log4net;
using System.IO;
using System.Configuration;
using BootstrapMVC.Helpers;
using MyResources;
using System.Globalization;
using System.Threading;

namespace BootstrapMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebAPIConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/BootstrapMVC/Web.config")));
            //log4net.Config.XmlConfigurator();
//            log4net.Config.XmlConfigurator.Configure(new FileInfo("Web.config"));

          //  FileInfo fileinfoPath = new FileInfo(Server.MapPath("~/BootstrapMVC/Web.config"));
           // log4net.Config.XmlConfigurator.Configure(new FileInfo("C:/Users/priyvasanthan/Documents/Visual Studio 2013/Projects/BootstrapMVC_IISExpress/BootstrapMVC/Web.config"));
           // log4net.Config.XmlConfigurator.Configure(new FileInfo(ConfigurationManager.AppSettings["fileinfoPath"]));
          //  UnhandledExceptionEventHandler

  
        
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //string _day = "Sat";
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
          //  Session["LocalResources"]  = "MyResources.Resources_Ta_In";
        }
        
    }
}
 