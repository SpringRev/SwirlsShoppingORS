﻿using System.Web;
using System.Web.Mvc;

namespace BootstrapMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
         //   filters.Add(new CustomAttributes.CustomAuthorizationAttribute());
        }
    }
}
