using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BootstrapMVC.Models;

namespace BootstrapMVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoresWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StoresWCFService.svc or StoresWCFService.svc.cs at the Solution Explorer and start debugging.
    public class StoresWCFService : IStoresWCFService
    {
        StoresEntities db = new StoresEntities();

        public void DoWork()
        {
        }

        void IStoresWCFService.DoWork()
        {
            throw new NotImplementedException();
        }

        List<Models.Product> IStoresWCFService.GetProducts()
        {
            List<Product> productsData = db.Products.ToList();
            return productsData;
        }
    }
}
