using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
    class Proxy
    {
    }





    public class proxyDp : IBuyService
    {
        private IBuyService service;

        public proxyDp(string userName, string password)
        {
            service = new BuyService();

        }


        public string BuyClothes(string id)
        {
        

            return service.BuyClothes(id);
        }

        public string GetPrices()
        {
            return service.GetPrices();
        }

 
   
  
    }

    

    /// <summary>
    /// Service to which we are oging to create proxy 
    /// </summary>
    public class BuyService : IBuyService
    {
        public bool isLoaded { get; protected set; } = false;

        public string GetPrices()
        {
            return "2.0";
        }

        public string BuyClothes(string id)
        {
            return "we have buyed clothes";
        }

        public void ReloadData()
        {
            isLoaded = true;
        }
    }

}
