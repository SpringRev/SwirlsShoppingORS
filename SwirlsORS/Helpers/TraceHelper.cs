using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace BootstrapMVC.Helpers
{
        public static class TraceHelper
        {
            public static void MyTrace(TraceLevel level, string message)
            {
                switch (level)
                {
                    case TraceLevel.Error:
                        Trace.TraceError(message);
                        break; 
                    case TraceLevel.Warning:
                        Trace.TraceWarning(message);
                        break;
                    case TraceLevel.Info:
                        Trace.TraceInformation(message);
                        break;
                    case TraceLevel.Verbose:
                        Trace.WriteLine(message);
                        break;
                }
            }
        }
}