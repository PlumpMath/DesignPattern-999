using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Structural
{
  public class  FacadeDP
    {

        public void Demonstrate()
        {
            var facadetmp = new Facade();

            Console.WriteLine(facadetmp.GetTempretureInformation("111"));
        }
     

      

    }





    public class Facade
    {
        private readonly TempretureService tempService;

        public Facade() 
        {
            tempService = new TempretureService();

        }


        public string GetTempretureInformation(string zipcode)
        {
            var city = tempService.GetCityByZip(zipcode);
            var state = tempService.GetStateByCity(city);
            var temp = tempService.GetTempretureByCity(city);

            return string.Format("curren ttempreture is {0} in {1} , {2}", temp, city, state);
        }

    }


    #region Anti Design Pattern

    /// <summary>
    /// anti patern shows that if w eare calling the service without facade we have the following porblem, we need to know the complexity of the api that we need instead of using it directlyu 
    /// </summary>
    public class FacadeAnti
    {

        public string GetTempreture(string zipCode)
        {
            var tempService = new TempretureService();

            var city = tempService.GetCityByZip(zipCode);
            var state = tempService.GetStateByCity(city);
            var temp = tempService.GetTempretureByCity(city);
            
            return string.Format("curren ttempreture is {0} in {1} , {2}",temp,city,state);
        }
    }

    #endregion 


    /// <summary>
    /// Service that will be called from the DP and Anti DP 
    /// </summary>
    public class TempretureService
    {
        public string GetCityByZip(string ZipCode)
        {
            return "Sofia";
        }

        public string GetStateByCity(string City)
        {
            return "Sofia-grad";
        }

        public string GetTempretureByCity(string City)
        {
            return string.Format("{0} F1",20);
        }
    }

}
