using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.IO;
using System.Web.SessionState;

namespace BootstrapMVC.CustomAttributes
{
    public class CustomAuthorizationAttribute : System.Web.Mvc.AuthorizeAttribute, System.Web.Mvc.IAuthorizationFilter
    {

        void System.Web.Mvc.IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var filterHttpContext = filterContext.RequestContext.HttpContext;
            if (Convert.ToBoolean(filterHttpContext.Session["IsAuthorized"]))
            {
                var strNext="Next";
            }

            else if (filterHttpContext.Request["txtUserName"].Equals("revathis"))
            {
                filterHttpContext.Session.Add("IsAuthorized",true);
                // do nothing
            }
            else
            {
                //filterContext.Result = new HttpUnauthorizedResult(); // mark unauthorized

                filterHttpContext.Response.Redirect("./SignIn.aspx", true);
            }
        }
    }
} 