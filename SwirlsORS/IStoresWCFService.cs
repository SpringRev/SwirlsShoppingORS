using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BootstrapMVC.Models;



namespace BootstrapMVC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoresWCFService" in both code and config file together.
    [ServiceContract]
    public interface IStoresWCFService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Product> GetProducts();
    }
}
