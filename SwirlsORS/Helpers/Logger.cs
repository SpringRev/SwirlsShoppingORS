using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace BootstrapMVC.Helpers
{
    public static class Logger
    {
        public readonly static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    }
}