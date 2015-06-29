using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Web.Helpers;
using System.Net;


namespace BootstrapMVC.Models
{
    public class NameComparer:IComparer<Product>
    {
        StringBuilder sb = new StringBuilder("Writing down the Bubble Sort");
        DateTime dt;
        

        public int Compare(Product x, Product y)
         {
            //StreamWriter sr= new StreamWriter()
             string filepath = @"C:\Users\priyvasanthan\Documents\Visual Studio 2013\Projects\BootstrapMVC\BootstrapMVC\Content\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";

             sb.Append("  ");
             sb.Append(x.ID);
             sb.Append("  ");
             sb.Append(y.ID);
             sb.AppendLine();

             string log= sb.ToString();
             Console.Write(log);

             StreamWriter sw = new StreamWriter(filepath, true);
             sw.WriteLine(log);
             sw.Flush();
             sw.Close();

             
          //   StreamWriter sw = new StreamWriter(@"C:\Users\priyvasanthan\Documents\Visual Studio 2013\Projects\BootstrapMVC\BootstrapMVC\Content\LogFile.txt");
            

            try 
            {
                if (string.Compare(x.Name, y.Name) > 1)
                    return 1;
                else if (string.Compare(x.Name, y.Name) < 1)
                    return -1;
                else return 0;
            }
            catch
            { 
            throw new NotImplementedException();
            }

        }
    }
}