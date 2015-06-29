using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapMVC.Helpers
{
    public  class UnhandledException
    {
            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException+ = currentDomain_UnhandledException;
  

       public static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
 
            // logging and warning messages
 
            Console.WriteLine("MyHandler caught : " + ex.Message);
            Console.WriteLine("Runtime terminating: {0}", e.IsTerminating);
 
        }
    }
}