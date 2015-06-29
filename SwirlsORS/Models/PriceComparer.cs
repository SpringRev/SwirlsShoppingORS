using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BootstrapMVC.Models
{
    public class PriceComparer:IComparer<Product>
    {

        public int Compare(Product x, Product y)
        {
            try 
            { 
                
                if (x.Price > y.Price) 
                    return 1;
                else if (x.Price < y.Price) 
                    return -1;
                else
                    return 0;
            }
            catch(ApplicationException appEx)
            {
                throw appEx;
            }
        }
    }
}