using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
   public class Proxy
    {

        public void demonstrate()
        {
            var prox = new proxyDp("aa","bbb");


            Console.WriteLine(prox.BuyClothes("1"));
            Console.WriteLine(prox.BuyClothes("1"));
        }

    }




    /// <summary>
    /// this is proxy design pattern which is checking does the service have connection and if it hasent it's returning default object till the service is loaded
    /// </summary>
    public class proxyDp : IBuyService
    {
        private IBuyService service;

        public proxyDp(string userName, string password)
        {
            service = new BuyService();

        }

        public bool isloaded
        { get; set;       
        }

        public string BuyClothes(string id)
        {
            string result = "not loaded this is default value";


            if(service.isloaded)
            {
                return service.BuyClothes(id);
            }

            service.ReloadData();
            return result;
        }

        public string GetPrices()
        {
            string result = "not loaded this is default value";

            if (service.isloaded)
            {
                return service.GetPrices(); ;
            }

            service.ReloadData();
            return result;
        }

        public void ReloadData()
        {
            isloaded = true;
        }
    }

    

    /// <summary>
    /// Service to which we are oging to create proxy 
    /// </summary>
    public class BuyService : IBuyService
    {
        public bool isloaded { get; set; } = false;

       

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
            isloaded = true;
        }
    }

}
