using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Text.RegularExpressions;



namespace BootstrapMVC.Helpers
{

    static class Program
    {
        [STAThread]
        static void Main(string[] argv)
        {
            double x = 12.34;
            Action<double> actionMethod = FormatInput;
            Action<double> actionDel =
                 delegate(double x1)
                 {
                     string format = "##.#";
                     Console.Write(x1.ToString(format));
                 };
            actionDel(x);
            Console.Write("Static Method as an action delegate");
            actionMethod(x);
            Console.ReadLine();
            Console.WriteLine("String Format Check with Func");

            string str= "Q_300000_1000";
            Func<string, bool> funcCheckFormat = CheckFormat;
            bool formatStatus = funcCheckFormat(str);
            Console.WriteLine("It's"+ formatStatus.ToString());
            Console.ReadLine();

            string[] checkStrings = { "Q_300000_1000", "P_30000_1000", "Q_3hFG45_1222", "Q_3000001_10001",
                                    "Q_302_105"};

            Regex regex = new Regex(@"^Q_3[a-zA-Z0-9]{5}_1\d{3}");
            foreach (string str1 in checkStrings)
            {
                Console.WriteLine(str1);
                Console.WriteLine(regex.IsMatch(str1).ToString());
            }
            Console.ReadLine();

            
           

            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
            //// Application.ThreadException += new UnhandledExceptionEventHandler(currentDomain_UnhandledException);
            //#region Unhandled Exception Test
            //string testUnhandle = null;
            //// testUnhandle.ToString();

            //#endregion
      
        }

        public static bool CheckFormat(string x1)
        {
          // string format = "Q_3#####_1###";
           bool formatStatus= false;
           Regex regex = new Regex(@"^Q_3\d{1,5}_1\d{1,3}");
            
          // Console.WriteLine(String.Format(x1, format));
           if (regex.IsMatch(x1))
               return true;
           return formatStatus;
        }
        public static void FormatInput(double x1)
        {
            string format = "Q_3#{1,5}_1#{1,3}";
            Console.Write(x1.ToString(format));
            Console.ReadLine();
        }

        public static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            // logging and warning messages

            Console.WriteLine("MyHandler caught : " + ex.Message);
            Console.WriteLine("Runtime terminating: {0}", e.IsTerminating);

        }
    }
}