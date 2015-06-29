using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using PayPal.Api;
using PayPal.Log;
using System.Security.Cryptography;
using System.Text;
using BootstrapMVC.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;



namespace BootstrapMVC
{
    public partial class PaypalAccess : System.Web.UI.Page
    {
       private StoresEntities db = new StoresEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {

            }


        }

        protected void btnSortMe_Click(object sender, EventArgs e)
        {
            int[] A = { 11, 2, 9, 4, 7 };
            int[] B= A;

          
            for (int i = A.Length; i > 0; i--)
            {
                  #if DEBUG
                        if ( i== 3)
                            System.Diagnostics.Debugger.Break();
                   #endif
               B= SortMe(A, i);
            }
            sortedList.DataSource = B.ToList();
            sortedList.DataBind();
            
            for(int j=0; j<B.Length;j++)
            {
             Response.Write(B[j].ToString());
             Response.Write("<br/>");

            }

        }

        private int[] SortMe(int[] B, int i)
        {
            for(int j=0;j<i-1;j++)
            {
                if (B[j] > B[j + 1])
                {
                    int temp = B[j + 1];
                    B[j + 1] = B[j];
                    B[j] = temp;
                }
                
            }
            return B;
        }

        protected void btnPaypal_Click(object sender, EventArgs e)
        {
            // Get a reference to the config
            var config = ConfigManager.Instance.GetProperties();

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            Response.Write(accessToken);

            var apiContext = new APIContext(accessToken);
            // Initialize the apiContext's configuration with the default configuration for this application.
            apiContext.Config = ConfigManager.Instance.GetProperties();

            // Define any custom configuration settings for calls that will use this object.
            apiContext.Config["connectionTimeout"] = "1000"; // Quick timeout for testing purposes

            // Define any HTTP headers to be used in HTTP requests made with this APIContext object
            if (apiContext.HTTPHeaders == null)
            {
                apiContext.HTTPHeaders = new Dictionary<string, string>();
            }
            apiContext.HTTPHeaders["some-header-name"] = "some-value";
            
        }

        public static void Print()
        {
            Console.WriteLine("Printing ..");
        }

        public sealed class Circle
        {
            private double radius=5;

            public double Calculate(Func<double, double> op)
            {
                return op(radius);
            }
        
        }

        protected void btnFunc_Click(object sender, EventArgs e)
        {
            double circum;
            Circle circle = new Circle();
            //Passing Lambda expression as a parameter for a delegate
            circum = circle.Calculate(r => 2 * Math.PI * r);
            //Answer would be 31.4159265358979
            Response.Write(circum);
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string dataToEncrypt = "revathis";
               // byte[] inputData = null;
                byte[] encryptedData;
               

               // inputData= Convert.ToByte(dataToEncrypt);

                using (RSACryptoServiceProvider rsaServiceProvider = new RSACryptoServiceProvider())
                {
                   // dataToEncrypt
                    //inputData = rsaServiceProvider.


                     encryptedData= rsaServiceProvider.Encrypt(Encoding.ASCII.GetBytes(dataToEncrypt), false);
                     Response.Write("Encrypted Data: ");
                     foreach (byte byteItem in encryptedData)
                     {
                         Response.Write(byteItem);
                     }


                    
                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        protected void btnUnhandledException_Click(object sender, EventArgs e)
        {
            string testUnhandle = null;
            testUnhandle.ToString();

        }

        protected void btnLambdaSamples_Click(object sender, EventArgs e)
        {
            TraceMessage("Something happened.");
          //List<Product> selectedList= db.Products.ToList();
          //dlProduct.DataSource = selectedList;
          //dlProduct.DataBind();

        }

        public void TraceMessage(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {

            Trace.Write("message: " + message); 
            Trace.Write("member name: " + memberName);
            Trace.Write("source file path: " + sourceFilePath);
            Trace.Write("source line number: " + sourceLineNumber);
        }

        protected void dlProduct_Load(object sender, EventArgs e)
        {

        }
    }
} 