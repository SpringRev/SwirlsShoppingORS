using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BootstrapMVC.Models;
using System.Data.Entity;


namespace BootstrapMVC
{
    /// <summary>
    /// Summary description for StoreWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StoreWebService : System.Web.Services.WebService
    {
        StoresEntities db= new StoresEntities();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<Product>  GetProducts()
        {
           List<Product> productsData= db.Products.ToList();
           return productsData;

        }
        [WebMethod]
        public Product GetProduct(int Id)
        {
            Product prod = db.Products.Find(Id);
            return prod;

        }
    }
}
